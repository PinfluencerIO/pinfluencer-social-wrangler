using System;
using System.IO;
using Pinf.InstaService.Bootstrapping.DevOps.Deploy;

namespace Pinf.InstaService.Bootstrapping.DevOps.Facades
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
                    Auth0 = new Auth0SettingsDto
                    {
                        Domain = "pinfluencer.eu.auth0.com",
                        Id = Environment.GetEnvironmentVariable( "AUTH0_ID" ),
                        Secret = Environment.GetEnvironmentVariable( "AUTH0_SECRET" ),
                        ManagementDomain = "https://pinfluencer.eu.auth0.com/api/v2/"
                    },
                    Bubble = new BubbleSettingsDto
                    {
                        Domain = "https://mobile-pinfluencer.bubbleapps.io/version-test/api/1.1/obj",
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