using System;
using System.Text.Json.Serialization;

namespace Pinf.InstaService.Core.Models.Insights
{
    public class AgeProperty
    {
        [ JsonPropertyName( "max" ) ]
        public int? Max { get; set; }
        
        [ JsonPropertyName( "min" ) ]
        public int Min { get; set; }
    }
}