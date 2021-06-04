using System;
using System.IO;
using Pinfluencer.SocialWrangler.Bootstrapping.DevOps.Deploy;

namespace Pinfluencer.SocialWrangler.Bootstrapping.DevOps.Facades
{
    public class PinfluencerDeploy
    {
        [ Target( Name = "test" ) ]
        public void Test( ) { Console.Write( Directory.GetCurrentDirectory( ) ); }

        [ Target( Name = "deploy" ) ]
        public void Deploy( )
        {
            new PinfluencerBeanstalkBuilder( )
                .CreateAppsettings( new AppsettingsDto
                {
                    AuthService = new AuthServiceSettingsDto
                    {
                        Domain = "pinfluencer.eu.auth0.com",
                        Id = Environment.GetEnvironmentVariable( "AUTH0_ID" ),
                        Secret = Environment.GetEnvironmentVariable( "AUTH0_SECRET" ),
                        ManagementDomain = "https://pinfluencer.eu.auth0.com/api/v2/"
                    },
                    PinfluencerData = new PinfluencerDataSettingsDto
                    {
                        Domain = "https://mobile-pinfluencer.bubbleapps.io/version-test/api/1.1/obj/",
                        Secret = Environment.GetEnvironmentVariable( "BUBBLE_TOKEN" )
                    },
                    SimpleAuthKey = Environment.GetEnvironmentVariable( "SIMPLE_AUTH_KEY" )
                } )
                .CreateNginx( )
                .CreateProcFile( )
                .ZipBundle( )
                .Deploy(
                    Environment.GetEnvironmentVariable( "AWS_ID" ),
                    Environment.GetEnvironmentVariable( "AWS_TOKEN" )
                );
        }
    }
}