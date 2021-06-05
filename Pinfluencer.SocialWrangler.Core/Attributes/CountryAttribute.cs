using System;

namespace Pinfluencer.SocialWrangler.Core.Attributes
{
    public class CountryAttribute : Attribute
    {
        public CountryAttribute( string name ) { Name = name; }

        public string Name { get; }
    }
}