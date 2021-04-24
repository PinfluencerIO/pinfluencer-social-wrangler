using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Pinf.InstaService.Bootstrapping.DevOps
{
    //TODO: configure dependency injection
    //TODO: configure IConfiguration to use options agnostic to config file/enviroment variables etc...
    class Program
    {
        static void Main(string[] args)
        {
            var (parameters, obj,target) = MapArguments(args);
            target.Invoke(obj,parameters);
        }

        private static string GetArgument(IEnumerable<string> args, string option)
            => args.SkipWhile(i => i != option).Skip(1).Take(1).FirstOrDefault();

        /// <exception cref="InvalidOperationException"></exception>
        private static (object[],object,MethodInfo) MapArguments(string[] args)
        {
            var target = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .SelectMany(x => x.GetMethods())
                .First(x =>
                    x.GetCustomAttribute<TargetAttribute>()?.Name == args[0]);

            var targetClass = target.DeclaringType;

            Debug.Assert(targetClass != null, nameof(targetClass) + " != null");

            foreach (var name in targetClass.GetConstructors().First().GetParameters().Select(x => GetArgument(args,$"--{x.Name}")))
            {
                Console.WriteLine(name);
            }

            var methodParams = args
                .Skip(1)
                .Skip(targetClass
                    .GetConstructors()
                    .First()
                    .GetParameters()
                    .Length)
                .Take(target
                    .GetParameters()
                    .Length)
                    .ToArray() as object[];
            
            var targetClassObject = Activator.CreateInstance(targetClass);
            return (methodParams,targetClassObject,target);
        }
    }
}