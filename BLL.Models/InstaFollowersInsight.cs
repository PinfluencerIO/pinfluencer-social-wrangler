namespace BLL.Models
{
    public class InstaFollowersInsight<T>
    {
        public T Property { get; }

        public int Count { get; }

        public InstaFollowersInsight(T property, int count)
        {
            Property = property;
            Count = count;
        }
    }
}