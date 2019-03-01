using System.Data;
using System.Data.SqlClient;
using PartnerGroup.Domain.Entities;
using PartnerGroup.Domain.Contracts;
using PartnerGroup.Domain.Converters;
using PartnerGroup.Domain.Shared.Repositories;

namespace PartnerGroup.DataAccess.Repositories
{
    public class BrandRepository : RepositoryBase<BrandEntity>, IBrandRepository
    {
        public BrandRepository() : base("Brand") { }

        public BrandEntity GetById(long id)
        {
            BrandEntity brand = null;
            var command = _connection.CreateCommand();
            command.CommandText = $"SELECT * FROM {_tableName} (NOLOCK) WHERE Id = Id";

            command.Parameters.Add(new SqlParameter("Id", id));
            if (_connection.State != ConnectionState.Open)
                command.Connection.Open();

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                brand = reader.ToEntity();
            }

            reader.Dispose();
            return brand;
        }

        public BrandEntity GetByName(string name)
        {
            BrandEntity brand = null;
            var command = _connection.CreateCommand();
            command.CommandText = $"SELECT * FROM {_tableName} (NOLOCK) WHERE Brand = @Branch";

            command.Parameters.Add(new SqlParameter("Branch", name));
            if (_connection.State != ConnectionState.Open)
                command.Connection.Open();

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                brand = reader.ToEntity();
            }

            reader.Dispose();
            return brand;
        }
    }
}
