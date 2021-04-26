using LibGit2Sharp;

namespace Pinf.InstaService.Bootstrapping.DevOps.Wrappers
{
    // add to service collection
    public static class GitAdapter
    {
        public static string GetBranch( string repositoryPath )
        {
            return new Repository( repositoryPath ).Head.FriendlyName;
        }

        public static string GetLatestCommit( string repositoryPath )
        {
            return new Repository( repositoryPath ).Head.Tip.Sha.Substring( 0, 7 );
        }
    }
}