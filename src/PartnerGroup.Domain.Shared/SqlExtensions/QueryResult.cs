using System;

namespace PartnerGroup.Domain.Shared.SqlExtensions
{
    public class QueryResult
    {
        private readonly Tuple<string, object> _result;

        public string Sql { get { return _result.Item1; } }
        public dynamic Parameters { get { return _result.Item2; } }

        public QueryResult(string sql, object param)
        {
            _result = new Tuple<string, object>(sql, param);
        }
    }
}
