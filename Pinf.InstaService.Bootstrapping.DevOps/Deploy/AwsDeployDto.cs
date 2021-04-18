using Amazon;

namespace Pinf.InstaService.Bootstrapping.DevOps.Deploy
{
    public class AwsDeployDto
    {
        public string Enviromnment { get; set; }
        
        public string EnviromnmentName { get; set; }
        
        public string Application { get; set; }
        
        public string File { get; set; }
        
        public string FilePath { get; set; }
        
        public string BucketName { get; set; }

        public string VersionLabel { get; set; }
    }
}