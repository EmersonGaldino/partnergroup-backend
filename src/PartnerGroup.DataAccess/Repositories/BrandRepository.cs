using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
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
            command.CommandText = $"SELECT * FROM {_tableName} WHERE Id = @Id";

            command.Parameters.Add(new SqlParameter("Id", id));
            if (_connection.State != ConnectionState.Open)
                command.Connection.Open();

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                brand = reader.ToBrandEntity();
            }

            reader.Dispose();
            return brand;
        }

        public BrandEntity GetByName(string name)
        {
            BrandEntity brand = null;
            var command = _connection.CreateCommand();
            command.CommandText = $"SELECT * FROM {_tableName} WHERE Brand = @Branch";

            command.Parameters.Add(new SqlParameter("Branch", name));
            if (_connection.State != ConnectionState.Open)
                command.Connection.Open();

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                brand = reader.ToBrandEntity();
            }

            reader.Dispose();
            return brand;
        }

        public IEnumerable<BrandEntity> Brands()
        {
            IList<BrandEntity> brands = new List<BrandEntity>();
            var command = _connection.CreateCommand();
            command.CommandText = $"SELECT * FROM {_tableName} (NOLOCK)";

            if (_connection.State != ConnectionState.Open)
                command.Connection.Open();

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                brands.Add(reader.ToBrandEntity());
            }

            reader.Dispose();
            return brands;
        }
    }
}
