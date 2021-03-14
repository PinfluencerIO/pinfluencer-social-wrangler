using Bootstrapping.Services.Enum;

namespace Bootstrapping.Services
{
    public class OperationResult<T>
    {
        public T Value { get; }

        public OperationResultEnum Status { get; }

        public OperationResult(T value, OperationResultEnum status)
        {
            Value = value;
            Status = status;
        }
    }
}