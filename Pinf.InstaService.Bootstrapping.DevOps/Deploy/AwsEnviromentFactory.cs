using System.Diagnostics;

namespace Pinf.InstaService.Bootstrapping.DevOps.Deploy
{
    public class AwsApplicationEnviromentFactory
    {
        public AwsApplicationEnviromentDto GetEnviroment( string appVersion )
        {
            switch( EnviromentFactory.GetEnviroment( ) )
            {
                case EnvironmentType.Production:
                    return new AwsApplicationEnviromentDto
                    {
                        Id = AwsPinfluencerConstants.EnvProd,
                        Name = AwsPinfluencerConstants.EnvNameProd,
                        AppVersion = $"{appVersion}-Prod"
                    };
                case EnvironmentType.Develop:
                    return new AwsApplicationEnviromentDto
                    {
                        Id = AwsPinfluencerConstants.EnvProd,
                        Name = AwsPinfluencerConstants.EnvNameProd,
                        AppVersion = $"{appVersion}-Dev"
                    };
                default:
                    Debug.Fail( "exception!!" );
                    return GetEmpty( );
            }
        }

        public static AwsApplicationEnviromentDto GetEmpty( ) { return new AwsApplicationEnviromentDto( ); }
    }
}