using Bootstrapping.Services.Enum;

namespace Bootstrapping.Services
{
    //TODO: provide message param to allow for meaningful error messages
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