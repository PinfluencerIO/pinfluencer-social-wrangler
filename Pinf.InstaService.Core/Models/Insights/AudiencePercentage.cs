﻿using System;
using System.Text.Json.Serialization;

namespace Pinf.InstaService.Core.Models.Insights
{
    public class AudiencePercentage<T>
    {
        private double _percentage;
        
        public double Percentage
        {
            get => _percentage;
            set => _percentage = Math.Round( value, 2 );
        }
        
        public T Value { get; set; }
    }
}