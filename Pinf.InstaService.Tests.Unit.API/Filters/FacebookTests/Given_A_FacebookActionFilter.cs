using System.Collections.Generic;
using Facebook;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using NSubstitute;
using Pinf.InstaService.API.InstaFetcher.Filters;
using Pinf.InstaService.API.InstaFetcher.Middleware;
using Pinf.InstaService.API.InstaFetcher.ResponseDtos;
using Pinf.InstaService.BLL.Core;
using Pinf.InstaService.BLL.Core.Enum;
using Pinf.InstaService.BLL.Core.Factories;
using Pinf.InstaService.BLL.Core.Repositories;
using Pinf.InstaService.Crosscutting.NUnit.Extensions;
using Pinf.InstaService.DAL.Instagram;

namespace Pinf.InstaService.Tests.Unit.API.Filters.FacebookTests
{
    //TODO: tests with factory
    public abstract class Given_A_FacebookActionFilter : AspActionFilterGivenWhenThen<FacebookActionFilter>
    {
        protected const string TestToken = "654321";
        protected const string TestAuth0Id = "12345";
        protected const string Auth0IdParamKey = "auth0_id";

        private FacebookContext _facebookContext;
        private IFacebookClientFactory _mockFacebookClientFactory;
        protected FacebookClient MockFacebookClient;
        protected IUserRepository MockUserRepository;

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

            Sut = new FacebookActionFilter( MockUserRepository, _facebookContext, _mockFacebookClientFactory );
        }

        protected void SetUpUserRepository( string value, OperationResultEnum resultEnum )
        {
            MockUserRepository
                .GetInstagramToken( Arg.Any<string>( ) )
                .Returns( new OperationResult<string>( value, resultEnum ) );
        }
        
        protected override Dictionary<string, StringValues> SetupQueryParams( ) =>
            new Dictionary<string, StringValues>{ { Auth0IdParamKey, TestAuth0Id } };
        
        protected string ErrorMessage => GetResultObject<UnauthorizedObjectResult, ErrorDto>( ).ErrorMsg;
    }
}