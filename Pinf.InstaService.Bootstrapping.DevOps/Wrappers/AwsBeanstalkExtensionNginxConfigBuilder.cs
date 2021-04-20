﻿using System;
using System.IO;
using System.Text;
using Pinf.InstaService.Bootstrapping.DevOps.Deploy;

namespace Pinf.InstaService.Bootstrapping.DevOps.Wrappers
{
    public class AwsBeanstalkExtensionNginxConfigBuilder
    {
        private readonly string _path;

        public AwsBeanstalkExtensionNginxConfigBuilder(string path)
        {
            _path = path;
        }
        
        public AwsBeanstalkExtensionNginxConfigBuilder AddReverseProxy(NginxReverseProxyDto config)
        {
            using var fs = File.OpenWrite($"{_path}{Path.DirectorySeparatorChar}{AwsBeanstalkConstants.NginxExtensionFile}");
            var firstLine = $"location {config.Url} "+"{"+Environment.NewLine;
            var secondLine = $"\tproxy_pass\thttp://127.0.0.1:{config.Port}/;{Environment.NewLine}";
            var thirdLine = "}";
            var info = new UTF8Encoding(true).GetBytes($"{firstLine}{secondLine}{thirdLine}");
            fs.Write(info, 0, info.Length);
            return this;
        }
        
        public AwsBeanstalkExtensionNginxConfigBuilder Create()
        {
            var file = new FileInfo($"{_path}{Path.DirectorySeparatorChar}{AwsBeanstalkConstants.NginxExtensionFile}");
            file.Directory?.Create();
            using var fs = File.Create($"{_path}{Path.DirectorySeparatorChar}{AwsBeanstalkConstants.NginxExtensionFile}");
            return this;
        }
    }
}