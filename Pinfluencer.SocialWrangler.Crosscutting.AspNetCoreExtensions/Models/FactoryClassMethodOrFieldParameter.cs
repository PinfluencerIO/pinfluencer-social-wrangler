using System;

namespace Pinfluencer.SocialWrangler.Crosscutting.AspNetCoreExtensions.Models
{
    internal class FactoryClassMethodOrFieldParameter
    {
        public Type Type { get; set; }
        public bool IsFromField { get; set; }
        public string MatchingField { get; set; }
        public bool IsFactoryReinjection { get; set; }
    }
}