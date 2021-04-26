using Pinf.InstaService.Bootstrapping.DevOps.Wrappers;

namespace Pinf.InstaService.Bootstrapping.DevOps.Deploy
{
    // TODO => add DI !!!
    public static class EnviromentFactory
    {
        public static EnvironmentType GetEnviroment( )
        {
            return GitAdapter.GetBranch( PinfluencerDeployConstants.RepositoryLocation ) switch
            {
                GitConstants.DevelopmentBranch => EnvironmentType.Develop,
                GitConstants.ProductionBranch => EnvironmentType.Production,
                _ => EnvironmentType.Develop
            };
        }
    }
}