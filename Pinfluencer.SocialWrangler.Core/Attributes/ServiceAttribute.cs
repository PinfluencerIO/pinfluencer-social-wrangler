using System;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Options;

namespace Pinfluencer.SocialWrangler.Core.Attributes
{
    [ AttributeUsage( AttributeTargets.Interface ) ]
    public class ServiceAttribute : Attribute
    {
        public Func<AppOptions> InjectableOptions { get; set; }
        public ServiceLifetimeEnum Scope { get; set; }
    }
}