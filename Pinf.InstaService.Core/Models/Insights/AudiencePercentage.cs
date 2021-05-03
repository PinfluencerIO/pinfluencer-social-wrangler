namespace Pinf.InstaService.Core.Models.Insights
{
    public class AudiencePercentage<T>
    {
        public decimal Percentage { get; set; }

        public T Value { get; set; }
    }
}