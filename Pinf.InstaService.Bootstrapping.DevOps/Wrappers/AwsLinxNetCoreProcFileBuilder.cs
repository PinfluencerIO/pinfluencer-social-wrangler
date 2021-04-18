using System;
using System.IO;
using System.Text;
using Pinf.InstaService.Bootstrapping.DevOps.Deploy;

namespace Pinf.InstaService.Bootstrapping.DevOps.Wrappers
{
    public class AwsLinxNetCoreProcFileBuilder
    {
        public AwsLinxNetCoreProcFileBuilder AddLine(ProcLineDto line,string procLocation="./")
        {
            using var fs = File.OpenWrite($"{procLocation}Procfile");
            var info = new UTF8Encoding(true).GetBytes(
                $"{line.Name}: dotnet exec {line.Location}{line.Namespace}.dll --urls http://0.0.0.0:{line.Port}/{Environment.NewLine}"
            );
            fs.Write(info, 0, info.Length);
            return this;
        }
        
        public AwsLinxNetCoreProcFileBuilder Create(string procLocation="./")
        {
            File.Create($"{procLocation}Procfile");
            return this;
        }
    }
}