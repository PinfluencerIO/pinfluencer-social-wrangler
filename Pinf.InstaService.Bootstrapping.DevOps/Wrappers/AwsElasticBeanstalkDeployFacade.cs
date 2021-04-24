using System;
using System.IO;
using Amazon;
using Amazon.ElasticBeanstalk;
using Amazon.ElasticBeanstalk.Model;
using Amazon.Internal;
using Amazon.S3;
using Amazon.S3.Transfer;
using Pinf.InstaService.Bootstrapping.DevOps.Deploy;

namespace Pinf.InstaService.Bootstrapping.DevOps.Wrappers
{
    //TODO: refactor into transient object behind interface
    //TODO: add wrapper around Aws services
    public static class AwsElasticBeanstalkDeployFacade
    {
        public static void UploadAndDeploy(AwsCredentialsDto credentials, AwsDeployDto deploy)
        {
            Console.WriteLine($"{deploy.FilePath}{Path.DirectorySeparatorChar}{deploy.File}");
            UploadFileToS3Bucket(credentials, deploy);
            DeployApplication(credentials, deploy);
        }

        private static void UploadFileToS3Bucket(AwsCredentialsDto credentials, AwsDeployDto deploy) =>
            new TransferUtility(new AmazonS3Client(credentials.Id, credentials.Token, RegionEndpoint.GetBySystemName(credentials.Region)))
                .Upload($"{deploy.FilePath}{Path.DirectorySeparatorChar}{deploy.File}", deploy.BucketName, $"{deploy.Application}/{deploy.File}");

        // TODO: validate errors :)) write tests :))))
        private static void DeployApplication(AwsCredentialsDto credentials, AwsDeployDto deploy)
        {
            var client = new AmazonElasticBeanstalkClient(credentials.Id, credentials.Token, RegionEndpoint.GetBySystemName(credentials.Region));
            client.CreateApplicationVersionAsync(new CreateApplicationVersionRequest(deploy.Application,deploy.VersionLabel)
            {
                SourceBundle = new S3Location{S3Bucket = deploy.BucketName, S3Key = $"{deploy.Application}/{deploy.File}"}
            }).Wait();
            client.UpdateEnvironmentAsync(new UpdateEnvironmentRequest
            {
                VersionLabel = deploy.VersionLabel,
                ApplicationName = deploy.Application,
                EnvironmentId = deploy.Enviromnment,
                EnvironmentName = deploy.EnviromnmentName
            }).Wait();
        }
        
        public static void TerminateEnvironment(AwsCredentialsDto credentials, AwsEnviromentDto env)
        {
            var client = new AmazonElasticBeanstalkClient(credentials.Id, credentials.Token, RegionEndpoint.GetBySystemName(credentials.Region));
            client.TerminateEnvironmentAsync(new TerminateEnvironmentRequest
            {
                EnvironmentId = env.Id,
                EnvironmentName = env.Name,
            }).Wait();
        }

        public static void RestoreEnvironment(AwsCredentialsDto credentials, AwsEnviromentDto env)
        {
            var client = new AmazonElasticBeanstalkClient(credentials.Id, credentials.Token, RegionEndpoint.GetBySystemName(credentials.Region));
            client.RebuildEnvironmentAsync(new RebuildEnvironmentRequest
            {
                EnvironmentId = env.Id,
                EnvironmentName = env.Name,
            }).Wait();
        }
    }
}