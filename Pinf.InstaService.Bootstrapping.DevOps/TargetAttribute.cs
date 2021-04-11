using System;

namespace Pinf.InstaService.Bootstrapping.DevOps
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TargetAttribute : Attribute
    {
        public string Name { get; set; }
    }
}