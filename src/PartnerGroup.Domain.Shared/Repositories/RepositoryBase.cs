using System.Data;
using System.Data.SqlClient;
using PartnerGroup.Domain.Shared.AppSettings;
using PartnerGroup.Domain.Shared.SqlExtensions;
using PartnerGroup.Domain.Shared.Contracts.Repositories;

namespace PartnerGroup.Domain.Shared.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly string _tableName;
        protected readonly SqlConnection _connection;
        public RepositoryBase(string tableName)
        {
            _tableName = tableName;
            _connection = new SqlConnection(Settings.ConnectionString);
        }

        internal virtual dynamic Mapping(TEntity item)
        {
            return item;
        }

        public void Add(TEntity item)
        {
            var parameters = (object)Mapping(item);
            _connection.Insert(_tableName, parameters);
        }

        public void Update(TEntity item)
        {
            var parameters = (object)Mapping(item);
            _connection.Update(_tableName, parameters);
        }

        public void Remove(long id)
        {
            var command = _connection.CreateCommand();
            command.CommandText = $"DELETE FROM {_tableName} WHERE Id = @Id";

            if (_connection.State != ConnectionState.Open)
                command.Connection.Open();

            command.Parameters.Add(new SqlParameter("Id", id));
            command.ExecuteNonQuery();
        }
    }
}
