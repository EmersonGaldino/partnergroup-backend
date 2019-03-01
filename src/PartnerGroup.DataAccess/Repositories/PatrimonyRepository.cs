using System.Data;
using System.Data.SqlClient;
using PartnerGroup.Domain.Queries;
using System.Collections.Generic;
using PartnerGroup.Domain.Entities;
using PartnerGroup.Domain.Contracts;
using PartnerGroup.Domain.Converters;
using PartnerGroup.Domain.Shared.Repositories;

namespace PartnerGroup.DataAccess.Repositories
{
    public class PatrimonyRepository : RepositoryBase<PatrimonyEntity>, IPatrimonyRepository
    {
        public PatrimonyRepository() : base("Patrimony") { }

        public PatrimonyEntity PatrimonyById(long id)
        {
            PatrimonyEntity patrimony = null;
            var command = _connection.CreateCommand();
            command.CommandText = PatrimonyQuery.Patrimonies;

            if (_connection.State != ConnectionState.Open)
                command.Connection.Open();

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                patrimony = reader.ToPatrimonyEntity();
            }

            reader.Dispose();
            return patrimony;
        }

        public IEnumerable<PatrimonyEntity> Patrimonies()
        {
            IList<PatrimonyEntity> patrimonies = new List<PatrimonyEntity>();
            var command = _connection.CreateCommand();
            command.CommandText = PatrimonyQuery.Patrimonies;

            if (_connection.State != ConnectionState.Open)
                command.Connection.Open();

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                patrimonies.Add(reader.ToPatrimonyEntity());
            }

            reader.Dispose();
            return patrimonies;
        }

        public IEnumerable<PatrimonyEntity> PatrimonyByBrandId(long brandId)
        {
            IList<PatrimonyEntity> patrimonies = new List<PatrimonyEntity>();
            var command = _connection.CreateCommand();
            command.CommandText = PatrimonyQuery.PatrimonyByBrandId;
            command.Parameters.Add(new SqlParameter("@BranchId", brandId));

            if (_connection.State != ConnectionState.Open)
                command.Connection.Open();

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                patrimonies.Add(reader.ToPatrimonyEntity());
            }

            reader.Dispose();
            return patrimonies;
        }
    }
}
