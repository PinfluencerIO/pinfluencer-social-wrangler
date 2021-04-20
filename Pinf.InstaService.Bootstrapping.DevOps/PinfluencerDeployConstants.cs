using System.IO;

namespace Pinf.InstaService.Bootstrapping.DevOps
{
    public static class PinfluencerDeployConstants
    {
        public static readonly string DeployBundleLocation = "deploy";
        public static readonly string AppsettingsFile = $"{DeployBundleLocation}{Path.DirectorySeparatorChar}appsettings.json";
        private static readonly int RepositoryLocationParentFolders = 0;
        public static string RepositoryLocation
        {
            get
            {
                var dir = Directory.GetCurrentDirectory();
                for (var i = 0; i < RepositoryLocationParentFolders; i++)
                {
                    dir = Directory.GetParent(dir).FullName;
                }
                return dir;
            }
        }
        public static string GetAbsoluteLocation(string relativePathToFile)
        {
            var dir = Directory.GetCurrentDirectory();
            for (var i = 0; i < RepositoryLocationParentFolders; i++)
            {
                dir = Directory.GetParent(dir).FullName;
            }
            return $"{dir}{Path.DirectorySeparatorChar}{relativePathToFile}";
        }
        public static readonly string ZippedDeployBundle = "Test.zip";
    }
}