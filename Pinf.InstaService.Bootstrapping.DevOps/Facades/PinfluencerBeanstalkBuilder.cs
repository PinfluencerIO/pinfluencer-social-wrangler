﻿using System.IO;
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
                .GetEnviroment(GitAdapter.GetBranch(PinfluencerDeployConstants.RepositoryLocation));
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
                        File = PinfluencerDeployConstants.ZippedDeployBundle,
                        VersionLabel = GitAdapter.GetLatestCommit(PinfluencerDeployConstants.RepositoryLocation),
                        FilePath = PinfluencerDeployConstants.RepositoryLocation
                    }
                );
            return this;
        }

        public PinfluencerBeanstalkBuilder CreateAppsettings(AppsettingsDto appsettingsDto)
        {
            var appsettingsBuilder = new AppsettingsBuilder<AppsettingsDto>(PinfluencerDeployConstants.GetAbsoluteLocation(
                PinfluencerDeployConstants.AppsettingsFile), appsettingsDto);
            return this;
        }
        
        public PinfluencerBeanstalkBuilder ZipBundle()
        {
            ZipFileAdapter
                .CreateFromDirectory(
                    PinfluencerDeployConstants.GetAbsoluteLocation(
                        PinfluencerDeployConstants.DeployBundleLocation),
                    PinfluencerDeployConstants.GetAbsoluteLocation(
                        PinfluencerDeployConstants.ZippedDeployBundle
                    ));
            return this;
        }
        
        public PinfluencerBeanstalkBuilder CreateProcFile()
        {
            new AwsLinxNetCoreProcFileBuilder(PinfluencerDeployConstants.GetAbsoluteLocation(
                    PinfluencerDeployConstants.DeployBundleLocation))
                .Create()
                .AddLine(new ProcLineDto
                {
                    Namespace = PinfluencerHostConstants.ProcessNamespace,
                    Port = PinfluencerHostConstants.ReverseProxyPort
                });
            return this;
        }
        
        public PinfluencerBeanstalkBuilder CreateNginx()
        {
            new AwsBeanstalkExtensionNginxConfigBuilder(PinfluencerDeployConstants.GetAbsoluteLocation(
                    PinfluencerDeployConstants.DeployBundleLocation))
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