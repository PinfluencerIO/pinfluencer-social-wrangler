using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using NSubstitute;
using Pinfluencer.SocialWrangler.API.Core.Dtos.Request;
using Pinfluencer.SocialWrangler.API.Core.Dtos.Response;
using Pinfluencer.SocialWrangler.API.Filters;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.Extensions;
using Pinfluencer.SocialWrangler.DAL.Common;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Factories;

namespace Pinfluencer.SocialWrangler.Tests.Unit.API.Filters.FacebookTests
{
    //TODO: tests with factory
    public abstract class Given_A_FacebookActionFilter : AspActionFilterGivenWhenThen<FacebookActionFilter>
    {
        protected const string TestToken = "654321";
        protected const string TestAuth0Id = "12345";
        protected const string Auth0IdParamKey = "auth-id";
        protected const string UserActionArgumentKey = "user";
        
        protected ISocialAuthManager MockSocialAuthManager;

        protected string ErrorMessage => GetResultObject<ErrorDto>( ).ErrorMsg;

        protected override void Given( )
        {
            base.Given( );
            MockSocialAuthManager = Substitute.For<ISocialAuthManager>( );
            SUT = new FacebookActionFilter( MvcAdapter, MockSocialAuthManager );
        }

        protected override Dictionary<string, StringValues> SetupQueryParams( )
        {
            return new Dictionary<string, StringValues> { { Auth0IdParamKey, TestAuth0Id } };
        }

        protected override Dictionary<string, object> SetupActionArguments( )
        {
            return new Dictionary<string, object> { { UserActionArgumentKey, new UserDto { Auth0Id = TestAuth0Id } } };
        }
    }
}