using System;

namespace Pinfluencer.SocialWrangler.Bootstrapping.DevOps
{
    [ AttributeUsage( AttributeTargets.Method ) ]
    public class TargetAttribute : Attribute
    {
        public string Name { get; set; }
    }
}