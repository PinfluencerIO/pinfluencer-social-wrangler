using BLL.InstagramFetcher.Enums;

namespace BLL.InstagramFetcher
{
    public class OperationResult<T>
    {
        public OperationResultEnum Status { get; set; }

        public T Value { get; set; }
    }
}