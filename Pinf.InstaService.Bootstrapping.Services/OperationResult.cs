using Pinf.InstaService.Bootstrapping.Services.Enum;

namespace Pinf.InstaService.Bootstrapping.Services
{
    //TODO: provide message param to allow for meaningful error messages
    public class OperationResult<T>
    {
        public OperationResult(T value, OperationResultEnum status)
        {
            Value = value;
            Status = status;
        }

        public T Value { get; }

        public OperationResultEnum Status { get; }
    }
}