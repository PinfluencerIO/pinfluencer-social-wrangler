using System.Diagnostics;

namespace Pinf.InstaService.Bootstrapping.DevOps.Deploy
{
    public class AwsEnviromentFactory
    {
        public AwsEnviromentDto GetEnviroment(string branch)
        {
            switch (branch)
            {
                case GitConstants.ProductionBranch:
                    return new AwsEnviromentDto
                    {
                        Id = AwsPinfluencerConstants.EnvProd,
                        Name = AwsPinfluencerConstants.EnvNameProd
                    };
                case GitConstants.DevelopmentBranch:
                    return new AwsEnviromentDto
                    {
                        Id = AwsPinfluencerConstants.EnvDev,
                        Name = AwsPinfluencerConstants.EnvNameDev
                    };
                default:
                    Debug.Fail("exception!!");
                    return GetEmpty();
            }
        }
        
        public static AwsEnviromentDto GetEmpty()
        {
            return new AwsEnviromentDto();
        }
    }
}