using System.Collections.Generic;
using Facebook;
using Microsoft.Extensions.Primitives;
using NSubstitute;
using Pinfluencer.SocialWrangler.API.Filters;
using Pinfluencer.SocialWrangler.API.RequestDtos;
using Pinfluencer.SocialWrangler.API.ResponseDtos;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Repositories;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.Extensions;
using Pinfluencer.SocialWrangler.DAL.Common;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Factories;

namespace Pinfluencer.SocialWrangler.Tests.Unit.API.Filters.FacebookTests
{
    //TODO: tests with factory
    public abstract class Given_A_FacebookActionFilter : AspActionFilterGivenWhenThen<FacebookActionFilter>
    {
        protected const string TestToken = "654321";
        protected const string TestAuth0Id = "12345";
        protected const string Auth0IdParamKey = "auth-id";
        protected const string UserActionArgumentKey = "user";

        private FacebookContext _facebookContext;
        private IFacebookClientFactory _mockFacebookClientFactory;
        protected FacebookClient MockFacebookClient;
        protected IUserRepository MockUserRepository;

        protected string ErrorMessage => GetResultObject<ErrorDto>( ).ErrorMsg;

        protected override void Given( )
        {
            base.Given( );

            MockUserRepository = Substitute.For<IUserRepository>( );
            _facebookContext = new FacebookContext( );
            _mockFacebookClientFactory = Substitute.For<IFacebookClientFactory>( );
            MockFacebookClient = Substitute.For<FacebookClient>( );

            _mockFacebookClientFactory
                .Get( Arg.Any<string>( ) )
                .Returns( MockFacebookClient );

            Sut = new FacebookActionFilter( MockUserRepository, _facebookContext, _mockFacebookClientFactory, MvcAdapter );
        }

        protected void SetUpUserRepository( string value, OperationResultEnum resultEnum )
        {
            MockUserRepository
                .GetInstagramToken( Arg.Any<string>( ) )
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