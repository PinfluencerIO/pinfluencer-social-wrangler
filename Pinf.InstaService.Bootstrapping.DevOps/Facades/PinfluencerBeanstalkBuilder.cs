using System.IO;
using Pinf.InstaService.Bootstrapping.DevOps.Deploy;
using Pinf.InstaService.Bootstrapping.DevOps.Wrappers;

namespace Pinf.InstaService.Bootstrapping.DevOps.Facades
{
    public class PinfluencerBeanstalkBuilder
    {
        public PinfluencerBeanstalkBuilder Deploy(
            string awsId,
            string awsToken
        )
        {
            var env = new AwsEnviromentFactory()
                .GetEnviroment(GitAdapter.GetBranch($"{Directory.GetCurrentDirectory()}{PinfluencerDeployConstants.RepositoryLocation}"));
            AwsElasticBeanstalkDeployFacade
                .UploadAndDeploy(
                    new AwsCredentialsDto
                    {
                        Id = awsId,
                        Token = awsToken,
                        Region = AwsPinfluencerConstants.Region
                    },
                    new AwsDeployDto
                    {
                        Application = AwsPinfluencerConstants.AppName,
                        BucketName = AwsPinfluencerConstants.S3Bucket,
                        Enviromnment = env.Id,
                        EnviromnmentName = env.Name,
                        File = PinfluencerDeployConstants.DeployBundle,
                        VersionLabel = GitAdapter.GetLatestCommit(PinfluencerDeployConstants.RepositoryLocation),
                        FilePath = PinfluencerDeployConstants.DeployBundleLocation
                    }
                );
            return this;
        }
        
        public PinfluencerBeanstalkBuilder CreateProcFile()
        {
            new AwsLinxNetCoreProcFileBuilder(PinfluencerDeployConstants.DeployBundleLocation)
                .Create()
                .AddLine(new ProcLineDto
                {
                    Namespace = PinfluencerHostConstants.ProcessNamespace
                });
            return this;
        }
        
        public PinfluencerBeanstalkBuilder CreateNginx()
        {
            new AwsBeanstalkExtensionNginxConfigBuilder(PinfluencerDeployConstants.DeployBundleLocation)
                .Create()
                .AddReverseProxy(new NginxReverseProxyDto
                {
                    Url = PinfluencerHostConstants.ApiUrl,
                    Port = PinfluencerHostConstants.ReverseProxyPort
                });
            return this;
        }
    }
}