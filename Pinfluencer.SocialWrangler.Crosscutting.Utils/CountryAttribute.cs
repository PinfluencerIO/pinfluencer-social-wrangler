using System;

namespace Pinfluencer.SocialWrangler.Crosscutting.Utils
{
    public class CountryAttribute : Attribute
    {
        public string Name { get; }

        public CountryAttribute( string name )
        {
            Name = name;
        }
    }
}