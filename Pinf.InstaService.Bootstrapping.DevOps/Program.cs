using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Pinf.InstaService.Bootstrapping.DevOps
{
    class Program
    {
        static void Main(string[] args)
            => MapArguments(args);

        private static string GetArgument(IEnumerable<string> args, string option)
            => args.SkipWhile(i => i != option).Skip(1).Take(1).FirstOrDefault();
        
        private static string[] GetKeys(IEnumerable<string> args)
            => args.Where((x,i) => i%2 == 0).Select(x => x.Skip(2).ToString()).ToArray();
        
        private static Tuple<string,string> GetArgumentWithKey(IEnumerable<string> args, string option)
        {
            var argsWithKey = args.SkipWhile(i => i != option).Take(2).ToArray();
            return new Tuple<string, string>(argsWithKey[0], argsWithKey[1]);
        }

        /// <exception cref="InvalidOperationException"></exception>
        private static void MapArguments(IEnumerable<string> args)
        {
            var target = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .SelectMany(x => x.GetMethods())
                .First(x => 
                    x.Name == GetArgument(args, "--target") && 
                    x.GetCustomAttributes(typeof(TargetAttribute)).Any());

            var targetClass = target.DeclaringType;

            Console.WriteLine($"Class: {targetClass?.Name}");

            Debug.Assert(targetClass != null, nameof(targetClass) + " != null");

            Console.WriteLine("Ctor params: ");
            
            foreach (var name in targetClass.GetConstructors().First().GetParameters().Select(x => GetArgument(args,$"--{x.Name}")))
            {
                Console.WriteLine(name);
            }

            var ctorParams = targetClass
                .GetConstructors()
                .First()
                .GetParameters()
                .Select(x => GetArgument(args, $"--{x.Name}")).ToArray();
            
            var methodParams = target
                .GetParameters()
                .Select(x => GetArgument(args, $"--{x.Name}")).ToArray();
            
            var targetClassObject = Activator.CreateInstance(targetClass,ctorParams);
            target.Invoke(targetClassObject,methodParams);
        }
    }
}