using System;
using System.Collections.Generic;
using System.Linq;

namespace Pinf.InstaService.Bootstrapping.DevOps
{
    class Program
    {
        static void Main(string[] args)=>
            Console.WriteLine(GetArgument(args,"task"));

        private static string GetArgument(IEnumerable<string> args, string option)
            => args.SkipWhile(i => i != option).Skip(1).Take(1).FirstOrDefault();
    }
}