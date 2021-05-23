using System;
using System.Collections.Generic;
using Auth0.ManagementApi;
using Facebook;
using NSubstitute;
using Pinfluencer.SocialWrangler.Core.Interfaces.Models;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.Core.Models.User;
using Pinfluencer.SocialWrangler.DAL.Common;
using Pinfluencer.SocialWrangler.DAL.Common.Handlers;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Clients;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Handlers;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Factories;

namespace Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions
{
    public class DataGivenWhenThen<T> : PinfluencerGivenWhenThen<T> where T : class
    {
        protected FacebookDecorator FacebookDecorator;
        protected Auth0Context Auth0Context;
        protected IFacebookClientAdapter MockFacebookClient;
        protected ISocialInfoUser SocialInfoUser;
        protected IManagementConnection MockAuth0ManagementApiConnection;
        protected CountryGetter CountryGetter;
        protected IBubbleDataHandler<T> MockBubbleDataHandler;
        protected IFacebookDataHandler<T> MockFacebookDataHandler;
        protected IBubbleClient MockBubbleClient;

        protected override void Given( )
        {
            base.Given( );
            CountryGetter = new CountryGetter( );
            MockBubbleClient = Substitute.For<IBubbleClient>( );
            MockAuth0ManagementApiConnection = Substitute.For<IManagementConnection>( );
            MockFacebookClient = Substitute.For<IFacebookClientAdapter>( );
            var facebookClientFactory = Substitute.For<IFacebookClientFactory>( );
            facebookClientFactory
                .Get( Arg.Any<string>( ) )
                .Returns( MockFacebookClient );
            FacebookDecorator = new FacebookDecorator( facebookClientFactory ) { Token = string.Empty };
            Auth0Context = new Auth0Context { ManagementApiClient = new ManagementApiClient( "token", "domain", MockAuth0ManagementApiConnection ) };
            MockBubbleDataHandler = Substitute.For<IBubbleDataHandler<T>>( );
            MockFacebookDataHandler = Substitute.For<IFacebookDataHandler<T>>( );
            SocialInfoUser = new SocialInfoUser( MockDateTime );
        }

        protected static IEnumerable<FacebookApiException> FacebookExceptionFixture( ) => new [ ]
        {
            new FacebookApiException( "api error" ),
            new FacebookApiLimitException( "limit error" ),
            new FacebookOAuthException( "oauth error" )
        };
    }
}