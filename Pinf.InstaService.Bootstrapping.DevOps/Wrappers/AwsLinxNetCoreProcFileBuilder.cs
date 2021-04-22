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
            using var fs = File.AppendText($"{_path}{Path.DirectorySeparatorChar}{AwsBeanstalkConstants.LinxProcFile}");
            fs.Write($"{line.Name}: dotnet exec {line.Location}{line.Namespace}.dll --urls http://0.0.0.0:{line.Port}/");
            return this;
        }
        
        public AwsLinxNetCoreProcFileBuilder Create()
        {
            var file = new FileInfo($"{_path}{Path.DirectorySeparatorChar}{AwsBeanstalkConstants.LinxProcFile}");
            file.Directory?.Create();
            using var fs = File.Create($"{_path}{Path.DirectorySeparatorChar}{AwsBeanstalkConstants.LinxProcFile}");
            return this;
        }
    }
}