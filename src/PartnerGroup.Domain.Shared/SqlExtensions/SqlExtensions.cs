using System;
using System.Linq;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;

namespace PartnerGroup.Domain.Shared.SqlExtensions
{
    public static class DapperExtensions
    {
        public static void Insert(this IDbConnection connection, string tableName, object param)
        {
            var command = connection.CreateCommand();
            command.CommandText = DynamicQuery.InsertQuery(tableName, param);

            if (connection.State != ConnectionState.Open)
                command.Connection.Open();

            CreateCommandWithParameters(command, param);

            command.ExecuteNonQuery();
        }

        public static void Update(this IDbConnection connection, string tableName, object param)
        {
            var command = connection.CreateCommand();
            command.CommandText = DynamicQuery.UpdateQuery(tableName, param);

            if (connection.State != ConnectionState.Open)
                command.Connection.Open();

            CreateCommandWithParameters(command, param);

            command.ExecuteNonQuery();
        }

        private static IDbCommand CreateCommandWithParameters(IDbCommand command, object @params)
        {
            string[] properties;
            PropertyInfo[] propsProperties = @params.GetType().GetProperties();
            if (@params.GetType().FullName.Contains("BrandEntity"))
                properties = propsProperties.Select(p => p.Name).ToArray();
            else
                properties = propsProperties.Where(x => x.Name != "Brand").Select(p => p.Name).ToArray();

            foreach (var property in properties)
            {
                var propertyValue = @params.GetType().GetProperty(property).GetValue(@params, null);
                command.Parameters.Add(new SqlParameter(property, propertyValue ?? DBNull.Value));
            }

            return command;
        }
    }
}
