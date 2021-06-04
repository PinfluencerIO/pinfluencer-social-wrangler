using System;
using Pinfluencer.SocialWrangler.Core.Enum;

namespace Pinfluencer.SocialWrangler.Core.Attributes
{
    [ AttributeUsage( AttributeTargets.Interface ) ]
    public class ServiceAttribute : Attribute
    {
        public ServiceLifetimeEnum Scope { get; set; }
    }
}