using System;
using System.Collections.Generic;
using Auth0.ManagementApi;
using Facebook;
using Newtonsoft.Json;
using NSubstitute;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.Crosscutting;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Clients;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Factories;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Handlers;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;
using Pinfluencer.SocialWrangler.DAL.Common;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer;

namespace Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions
{
    public class DataGivenWhenThen<T> : PinfluencerGivenWhenThen<T> where T : class
    {
        protected IAuthServiceManagementClientDecorator MockAuthServiceManagementClientDecorator;
        protected CountryGetter CountryGetter;
        protected IFacebookDecorator MockFacebookDecorator;
        protected IBubbleDataHandler<T> MockBubbleDataHandler;
        protected IFacebookDataHandler<T> MockFacebookDataHandler;
        protected ISerializer Serializer;

        protected override void Given( )
        {
            base.Given( );
            Serializer = new JsonSerialzierAdapter( new PinfluencerJsonResolver( ) );
            CountryGetter = new CountryGetter( );
            MockFacebookDecorator = Substitute.For<IFacebookDecorator>( );
            MockAuthServiceManagementClientDecorator = Substitute.For<IAuthServiceManagementClientDecorator>( );
            MockBubbleDataHandler = Substitute.For<IBubbleDataHandler<T>>( );
            MockFacebookDataHandler = Substitute.For<IFacebookDataHandler<T>>( );
            CurrentTime = new DateTime( 2021, 5, 28 );
        }

        protected static IEnumerable<FacebookApiException> FacebookExceptionFixture( )
        {
            return new [ ]
            {
                new FacebookApiException( "api error" ),
                new FacebookApiLimitException( "limit error" ),
                new FacebookOAuthException( "oauth error" )
            };
        }

        protected static object ToJsonObject( object content ) =>
            JsonConvert.DeserializeObject( JsonConvert
                .SerializeObject( content ) );
    }
}