using System.IO;
using System.Text;
using Amazon;
using Pinf.InstaService.Bootstrapping.DevOps.Wrappers;

namespace Pinf.InstaService.Bootstrapping.DevOps.Deploy
{
    public class PinfluencerDeploy
    {
        [Target(Name = "deploy")]
        public void Deploy(
            string awsId,
            string awsToken
        )
        { 
            AwsElasticBeanstalkDeployFacade
                .UploadAndDeploy(
                    new AwsCredentialsDto
                    {
                        Id = awsId,
                        Token = awsToken,
                        Region = AwsEbConstants.Region
                    },
                    new AwsDeployDto
                    {
                        Application = AwsEbConstants.AppName,
                        BucketName = "",
                        Enviromnment = "",
                        EnviromnmentName = "",
                        File = "",
                        VersionLabel = ""
                    }
                );
        }
        
        [Target(Name = "addprocfile")]
        public void AddProcFile(string file)
        {
            new AwsLinxNetCoreProcFileBuilder()
                .Create()
                .AddLine(new ProcLineDto()
                {
                    Namespace = "Pinf.InstaService.API.InstaFetcher"
                });
        }
    }
}