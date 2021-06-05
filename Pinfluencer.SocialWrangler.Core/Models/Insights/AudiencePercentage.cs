using System;

namespace Pinfluencer.SocialWrangler.Core.Models.Insights
{
    public class AudiencePercentage<T>
    {
        private double _percentage;
        public Audience Audience { get; set; }

        public string Id { get; set; }

        public double Percentage
        {
            get => _percentage;
            set => _percentage = Math.Round( value, 2 );
        }

        public T Value { get; set; }
    }
}