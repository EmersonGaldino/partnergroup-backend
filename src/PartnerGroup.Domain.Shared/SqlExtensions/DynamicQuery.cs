using System.Linq;
using System.Reflection;

namespace PartnerGroup.Domain.Shared.SqlExtensions
{
    public sealed class DynamicQuery
    {
        public static string InsertQuery(string tableName, object item)
        {
            PropertyInfo[] props = item.GetType().GetProperties();
            if (item.GetType().FullName.Contains("BrandEntity"))
                props = props.Where(x => !x.CustomAttributes.Any()).ToArray();
            else
                props = props.Where(x => !x.CustomAttributes.Any() && x.Name != "Brand").ToArray();

            string[] columns = props.Select(p => p.Name).Where(s => s != "Id").ToArray();

            var command = $"INSERT INTO {tableName} ({string.Join(",", columns)}) VALUES(@{string.Join(",@", columns)})";
            return command;
        }

        public static string UpdateQuery(string tableName, object item)
        {
            PropertyInfo[] props = item.GetType().GetProperties();
            if (item.GetType().FullName.Contains("BrandEntity"))
                props = props.Where(x => !x.CustomAttributes.Any()).ToArray();
            else
                props = props.Where(x => !x.CustomAttributes.Any() && x.Name != "Brand").ToArray();

            string[] columns = props.Select(p => p.Name).Where(s => s != "Id").ToArray();
            var parameters = columns.Select(name => name + "=@" + name).ToList();

            var command = $"UPDATE {tableName} SET { string.Join(",", parameters) } WHERE Id=@Id";
            return command;
        }
    }
}
