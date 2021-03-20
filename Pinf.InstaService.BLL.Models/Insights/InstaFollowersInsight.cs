namespace Pinf.InstaService.BLL.Models.Insights
{
    public class InstaFollowersInsight<T>
    {
        public InstaFollowersInsight(T property, int count)
        {
            Property = property;
            Count = count;
        }

        public T Property { get; }

        public int Count { get; }
    }
}