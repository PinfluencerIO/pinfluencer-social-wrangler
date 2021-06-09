using System.Collections.Generic;
using System.Reflection;

namespace Pinfluencer.SocialWrangler.Crosscutting.AspNetCoreExtensions.Models
{
    internal class FactoryClassMethod
    {
        public MethodInfo FactoryInterfaceMethodInfo { get; set; }
        public ConstructorInfo MatchingCtor { get; set; }
        public List<FactoryClassMethodOrFieldParameter> Parameters { get; set; }
    }
}