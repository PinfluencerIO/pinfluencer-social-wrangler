using System;
using System.IO;
using System.Text;
using Amazon;
using Pinf.InstaService.Bootstrapping.DevOps.Facades;
using Pinf.InstaService.Bootstrapping.DevOps.Wrappers;

namespace Pinf.InstaService.Bootstrapping.DevOps.Deploy
{
    public class PinfluencerDeploy
    {
        [Target(Name = "test")]
        public void Test()
        {
            Console.Write(Directory.GetCurrentDirectory());
        }
        
        [Target(Name = "deploy")]
        public void Deploy()
        {
            new PinfluencerBeanstalkBuilder()
                .CreateAppsettings(new AppsettingsDto
                {
                    Auth0 = new Auth0SettingsDto
                    {
                        Domain = "pinfluencer.eu.auth0.com",
                        Id = Environment.GetEnvironmentVariable("AUTH0_ID"),
                        Secret = Environment.GetEnvironmentVariable("AUTH0_SECRET"),
                        ManagementDomain = "https://pinfluencer.eu.auth0.com/api/v2/"
                    },
                    SimpleAuthKey = Environment.GetEnvironmentVariable("SIMPLE_AUTH_KEY"),
                })
                .CreateNginx()
                .ZipBundle()
                .Deploy(
                    Environment.GetEnvironmentVariable("AWS_ID"),
                    Environment.GetEnvironmentVariable("AWS_TOKEN")
                );
        }
    }
}