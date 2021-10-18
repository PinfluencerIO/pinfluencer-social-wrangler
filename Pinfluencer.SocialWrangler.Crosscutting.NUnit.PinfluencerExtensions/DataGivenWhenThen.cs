using System;
using System.Collections.Generic;
using Aidan.Common.Core.Interfaces.Contract;
using Aidan.Common.Utils.Utils;
using Aidan.Common.Utils.Web;
using Facebook;
using Newtonsoft.Json;
using NSubstitute;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Clients;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Handlers;

namespace Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions
{
    public class DataGivenWhenThen<T> : PinfluencerGivenWhenThen<T> where T : class
    {
        protected IAuthServiceManagementClientDecorator MockAuthServiceManagementClientDecorator;
        protected ICountryGetter CountryGetter;
        protected IFacebookDecorator MockFacebookDecorator;
        protected IBubbleDataHandler<T> MockBubbleDataHandler;
        protected IFacebookDataHandler<T> MockFacebookDataHandler;
        protected ISerializer Serializer;
        protected DateTime CurrentTimeMinus1Day = new DateTime( 2021, 5, 27 );

        protected override void Given( )
        {
            base.Given( );
            Serializer = new JsonSnakeCaseSerialzier( new JsonSnakeCaseResolver( new JsonSnakeCaseFieldNameParser( ) ) );
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