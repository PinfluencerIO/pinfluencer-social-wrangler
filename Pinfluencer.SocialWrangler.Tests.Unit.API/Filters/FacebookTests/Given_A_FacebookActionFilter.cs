using System.Collections.Generic;
using Facebook;
using Microsoft.Extensions.Primitives;
using NSubstitute;
using Pinfluencer.SocialWrangler.API.Filters;
using Pinfluencer.SocialWrangler.API.RequestDtos;
using Pinfluencer.SocialWrangler.API.ResponseDtos;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Clients;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Factories;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.Extensions;
using Pinfluencer.SocialWrangler.DAL.Common;

namespace Pinfluencer.SocialWrangler.Tests.Unit.API.Filters.FacebookTests
{
    //TODO: tests with factory
    public abstract class Given_A_FacebookActionFilter : AspActionFilterGivenWhenThen<FacebookActionFilter>
    {
        protected const string TestToken = "654321";
        protected const string TestAuth0Id = "12345";
        protected const string Auth0IdParamKey = "auth-id";
        protected const string UserActionArgumentKey = "user";

        private FacebookDecorator _facebookDecorator;
        private IFacebookClientFactory _mockFacebookClientFactory;
        protected IFacebookClientAdapter MockFacebookClient;
        protected ITokenRepository MockTokenRepository;

        protected string ErrorMessage => GetResultObject<ErrorDto>( ).ErrorMsg;

        protected override void Given( )
        {
            base.Given( );
            MockTokenRepository = Substitute.For<ITokenRepository>( );
            MockFacebookClient = Substitute.For<IFacebookClientAdapter>( );
            var facebookClientFactory = Substitute.For<IFacebookClientFactory>( );
            facebookClientFactory
                .Factory( Arg.Any<string>( ) )
                .Returns( MockFacebookClient );
            _facebookDecorator = new FacebookDecorator( facebookClientFactory, Serializer );

            SUT = new FacebookActionFilter( _facebookDecorator, _mockFacebookClientFactory, MvcAdapter, MockTokenRepository );
        }

        protected void SetUpUserRepository( string value, OperationResultEnum resultEnum )
        {
            MockTokenRepository
                .Get( Arg.Any<string>( ) )
                .Returns( new OperationResult<string>( value, resultEnum ) );
        }

        protected override Dictionary<string, StringValues> SetupQueryParams( )
        {
            return new Dictionary<string, StringValues> { { Auth0IdParamKey, TestAuth0Id } };
        }

        protected override Dictionary<string, object> SetupActionArguments( )
        {
            return new Dictionary<string, object> { { UserActionArgumentKey, new UserDto{ Auth0Id = TestAuth0Id } } };
        }
    }
}