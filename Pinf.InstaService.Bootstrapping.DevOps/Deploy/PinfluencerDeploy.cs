using System;
using System.IO;
using System.Text;
using Amazon;
using Pinf.InstaService.Bootstrapping.DevOps.Facades;
using Pinf.InstaService.Bootstrapping.DevOps.Wrappers;

namespace Pinf.InstaService.Bootstrapping.DevOps.Deploy
{
    public class PinfluencerDeploy
    {
        [Target(Name = "deploy")]
        public void Deploy()
        {
            new PinfluencerBeanstalkBuilder()
                .CreateNginx()
                .CreateProcFile()
                .Deploy(
                    Environment.GetEnvironmentVariable("AWS_ID"),
                    Environment.GetEnvironmentVariable("AWS_TOKEN")
                );
        }
    }
}