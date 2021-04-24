using System;
using Pinf.InstaService.Bootstrapping.DevOps.Deploy;
using Pinf.InstaService.Bootstrapping.DevOps.Wrappers;

namespace Pinf.InstaService.Bootstrapping.DevOps.Facades
{
    public class PinfluencerRestartStart
    {
        [Target(Name = "close")]
        public void CloseServer()
        {
            AwsElasticBeanstalkDeployFacade
                .TerminateEnvironment(
                    new AwsCredentialsDto
                    {
                        Id = Environment.GetEnvironmentVariable("AWS_ID"),
                        Token = Environment.GetEnvironmentVariable("AWS_TOKEN"),
                        Region = AwsPinfluencerConstants.Region
                    },
                    new AwsEnviromentDto
                    {
                        Id = AwsPinfluencerConstants.EnvProd,
                        Name = AwsPinfluencerConstants.EnvNameProd
                    }
                );
        }

        [Target(Name = "open")]
        public void OpenServer()
        {
            AwsElasticBeanstalkDeployFacade
                .RestoreEnvironment(
                    new AwsCredentialsDto
                    {
                        Id = Environment.GetEnvironmentVariable("AWS_ID"),
                        Token = Environment.GetEnvironmentVariable("AWS_TOKEN"),
                        Region = AwsPinfluencerConstants.Region
                    },
                    new AwsEnviromentDto
                    {
                        Id = AwsPinfluencerConstants.EnvProd,
                        Name = AwsPinfluencerConstants.EnvNameProd
                    }
                );
        }
    }
}