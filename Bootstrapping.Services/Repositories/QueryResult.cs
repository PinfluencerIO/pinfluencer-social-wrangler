using Bootstrapping.Services.Enum;

namespace Bootstrapping.Services.Repositories
{
    public class QueryResult<T>
    {
        public T Value { get; }

        public QueryResultEnum Status { get; }

        public QueryResult(T value, QueryResultEnum status)
        {
            Value = value;
            Status = status;
        }
    }
}