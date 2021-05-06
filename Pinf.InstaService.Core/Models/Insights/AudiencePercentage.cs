using System;

namespace Pinf.InstaService.Core.Models.Insights
{
    public class AudiencePercentage<T>
    {
        public Audience Audience { get; set; }
        
        public string Id { get; set; }
        
        private double _percentage;
        
        public double Percentage
        {
            get => _percentage;
            set => _percentage = Math.Round( value, 2 );
        }
        
        public T Value { get; set; }
    }
}