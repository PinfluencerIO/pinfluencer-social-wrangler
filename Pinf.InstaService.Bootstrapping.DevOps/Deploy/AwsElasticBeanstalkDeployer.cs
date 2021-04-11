using System;

namespace Pinf.InstaService.Bootstrapping.DevOps.Deploy
{
    public class AwsElasticBeanstalkDeployer
    {
        private readonly string _id;
        private readonly string _token;

        public AwsElasticBeanstalkDeployer(string id, string token)
        {
            _id = id;
            _token = token;
        }
        
        [Target(Name = "upload")]
        public void UploadAndDeploy(string enviromnent, string application)
        {
            Console.WriteLine($"{_id}...{_token}...{enviromnent}...{application}");
        }
    }
}