using System.Collections.Generic;
using Auth0.ManagementApi;
using Facebook;
using NSubstitute;
using Pinf.InstaService.Core.Interfaces.Models;
using Pinf.InstaService.Core.Models.User;
using Pinf.InstaService.DAL.Common;
using Pinf.InstaService.DAL.UserManagement;

namespace Pinf.InstaService.Crosscutting.NUnit.PinfluencerExtensions
{
    public class DataGivenWhenThen<T> : PinfluencerGivenWhenThen<T> where T : class
    {
        protected FacebookContext FacebookContext;
        protected Auth0Context Auth0Context;
        protected FacebookClient MockFacebookClient => FacebookContext.FacebookClient;
        protected IUser User;
        protected IManagementConnection MockAuth0ManagementApiConnection;

        protected override void Given( )
        {
            base.Given( );
            MockAuth0ManagementApiConnection = Substitute.For<IManagementConnection>( );
            FacebookContext = new FacebookContext { FacebookClient = Substitute.For<FacebookClient>( ) };
            Auth0Context = new Auth0Context( ){ ManagementApiClient = new ManagementApiClient( "token", "domain", MockAuth0ManagementApiConnection ) };
            User = new User( MockDateTime );
        }

        protected static IEnumerable<FacebookApiException> FacebookExceptionFixture( ) => new [ ]
        {
            new FacebookApiException( "api error" ),
            new FacebookApiLimitException( "limit error" ),
            new FacebookOAuthException( "oauth error" )
        };
    }
}