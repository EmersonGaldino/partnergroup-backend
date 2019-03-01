using System;
using System.Text;
using System.Linq;
using System.Dynamic;
using System.Reflection;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace PartnerGroup.Domain.Shared.SqlExtensions
{
    public sealed class DynamicQuery
    {
        public static string InsertQuery(string tableName, object item)
        {
            PropertyInfo[] props = item.GetType().GetProperties();
            props = props.Where(x => !x.CustomAttributes.Any()).ToArray();

            string[] columns = props.Select(p => p.Name).Where(s => s != "Id").ToArray();

            var command = $"INSERT INTO {tableName} ({string.Join(",", columns)}) VALUES(@{string.Join(",@", columns)})";
            return command;
        }

        public static string UpdateQuery(string tableName, object item)
        {
            PropertyInfo[] props = item.GetType().GetProperties();
            props = props.Where(x => !x.CustomAttributes.Any()).ToArray();

            string[] columns = props.Select(p => p.Name).Where(s => s != "Id").ToArray();
            var parameters = columns.Select(name => name + "=@" + name).ToList();

            var command = $"UPDATE {tableName} SET { string.Join(",", parameters) } WHERE Id=@Id";
            return command;
        }

        public static QueryResult GetDynamicQuery<T>(string tableName, Expression<Func<T, bool>> expression)
        {
            var queryProperties = new List<QueryParameter>();
            var body = (BinaryExpression)expression.Body;

            IDictionary<string, Object> expando = new ExpandoObject();
            var builder = new StringBuilder();

            WalkTree(body, ExpressionType.Default, ref queryProperties);

            builder.Append("SELECT * FROM ");
            builder.Append($"dbo.[{tableName}] (NOLOCK)");
            builder.Append(" WHERE ");

            for (int i = 0; i < queryProperties.Count(); i++)
            {
                QueryParameter item = queryProperties[i];

                if (!string.IsNullOrEmpty(item.LinkingOperator) && i > 0)
                {
                    builder.Append(string.Format("{0} [{1}] {2} @{1} ", item.LinkingOperator, item.PropertyName, item.QueryOperator));
                }
                else
                {
                    builder.Append(string.Format("[{0}] {1} @{0} ", item.PropertyName, item.QueryOperator));
                }

                expando[item.PropertyName] = item.PropertyValue;
            }

            return new QueryResult(builder.ToString().TrimEnd(), expando);
        }

        private static void WalkTree(BinaryExpression body, ExpressionType linkingType, ref List<QueryParameter> queryProperties)
        {
            if (body.NodeType != ExpressionType.AndAlso && body.NodeType != ExpressionType.OrElse)
            {
                string propertyName = GetPropertyName(body);
                object propertyValue = Expression.Lambda(body.Right).Compile().DynamicInvoke();
                string opr = GetOperator(body.NodeType);
                string link = GetOperator(linkingType);

                queryProperties.Add(new QueryParameter(link, propertyName, propertyValue, opr));
            }
            else
            {
                WalkTree((BinaryExpression)body.Left, body.NodeType, ref queryProperties);
                WalkTree((BinaryExpression)body.Right, body.NodeType, ref queryProperties);
            }
        }

        private static string GetPropertyName(BinaryExpression body)
        {
            string propertyName = body.Left.ToString().Split(new char[] { '.' })[1];

            if (body.Left.NodeType == ExpressionType.Convert)
            {
                propertyName = propertyName.Replace(")", string.Empty);
            }

            return propertyName;
        }

        private static string GetOperator(ExpressionType type)
        {
            switch (type)
            {
                case ExpressionType.Equal:
                    return "=";
                case ExpressionType.NotEqual:
                    return "!=";
                case ExpressionType.LessThan:
                    return "<";
                case ExpressionType.GreaterThan:
                    return ">";
                case ExpressionType.AndAlso:
                case ExpressionType.And:
                    return "AND";
                case ExpressionType.Or:
                case ExpressionType.OrElse:
                    return "OR";
                case ExpressionType.Default:
                    return string.Empty;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
