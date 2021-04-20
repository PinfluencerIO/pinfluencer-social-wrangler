using System;
using System.IO;
using System.Text;
using Pinf.InstaService.Bootstrapping.DevOps.Deploy;

namespace Pinf.InstaService.Bootstrapping.DevOps.Wrappers
{
    public class AwsLinxNetCoreProcFileBuilder
    {
        private readonly string _path;

        public AwsLinxNetCoreProcFileBuilder(string path)
        {
            _path = path;
        }
        
        public AwsLinxNetCoreProcFileBuilder AddLine(ProcLineDto line)
        {
            using var fs = File.OpenWrite($"{_path}\\{AwsBeanstalkConstants.LinxProcFile}");
            var info = new UTF8Encoding(true).GetBytes(
                $"{line.Name}: dotnet exec {line.Location}{line.Namespace}.dll --urls http://0.0.0.0:{line.Port}/{Environment.NewLine}"
            );
            fs.Write(info, 0, info.Length);
            return this;
        }
        
        public AwsLinxNetCoreProcFileBuilder Create()
        {
            var file = new FileInfo($"{_path}\\{AwsBeanstalkConstants.LinxProcFile}");
            file.Directory?.Create();
            using var fs = File.Create($"{_path}\\{AwsBeanstalkConstants.LinxProcFile}");
            return this;
        }
    }
}