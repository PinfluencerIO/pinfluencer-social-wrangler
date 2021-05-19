﻿using System.Collections.Generic;
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

namespace Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions
{
    public class DataGivenWhenThen<T> : PinfluencerGivenWhenThen<T> where T : class
    {
        protected FacebookContext FacebookContext;
        protected Auth0Context Auth0Context;
        protected FacebookClient MockFacebookClient => FacebookContext.FacebookClient;
        protected ISocialInfoUser SocialInfoUser;
        protected IManagementConnection MockAuth0ManagementApiConnection;
        protected CountryGetter CountryGetter;
        protected IBubbleDataHandler<T> MockBubbleDataHandler;
        protected IBubbleClient MockBubbleClient;

        protected override void Given( )
        {
            base.Given( );
            CountryGetter = new CountryGetter( );
            MockBubbleClient = Substitute.For<IBubbleClient>( );
            MockAuth0ManagementApiConnection = Substitute.For<IManagementConnection>( );
            FacebookContext = new FacebookContext { FacebookClient = Substitute.For<FacebookClient>( ) };
            Auth0Context = new Auth0Context { ManagementApiClient = new ManagementApiClient( "token", "domain", MockAuth0ManagementApiConnection ) };
            MockBubbleDataHandler = Substitute.For<IBubbleDataHandler<T>>( );
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