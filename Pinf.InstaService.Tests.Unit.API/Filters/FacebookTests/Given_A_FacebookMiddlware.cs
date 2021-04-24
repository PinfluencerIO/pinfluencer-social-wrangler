using System.Collections.Generic;
using Facebook;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using NSubstitute;
using Pinf.InstaService.API.InstaFetcher.Middleware;
using Pinf.InstaService.BLL.Core;
using Pinf.InstaService.BLL.Core.Enum;
using Pinf.InstaService.BLL.Core.Factories;
using Pinf.InstaService.BLL.Core.Repositories;
using Pinf.InstaService.Crosscutting.NUnit.Extensions;
using Pinf.InstaService.DAL.Instagram;

namespace Pinf.InstaService.Tests.Unit.API.Filters.FacebookTests
{
    public abstract class Given_A_FacebookMiddlware : AspActionFilterGivenWhenThen<FacebookAttribute>
    {
        protected const string TestToken = "654321";
        protected const string TestAuth0Id = "12345";
        protected const string Auth0IdParamKey = "auth0_id";
        
        protected FacebookContext FacebookContext;
        protected FacebookClient MockFacebookClient;
        protected IFacebookClientFactory MockFacebookClientFactory;
        protected IUserRepository MockUserRepository;

        protected override void Given( )
        {
            MockUserRepository = Substitute.For<IUserRepository>( );
            FacebookContext = new FacebookContext( );
            MockFacebookClientFactory = Substitute.For<IFacebookClientFactory>( );
            MockFacebookClient = Substitute.For<FacebookClient>( );
            
            MockFacebookClientFactory
                .Get( Arg.Any<string>( ) )
                .Returns( MockFacebookClient );

            Sut = new FacebookAttribute( MockUserRepository, FacebookContext, MockFacebookClientFactory );
        }

        protected void SetUpUserRepository( string value, OperationResultEnum resultEnum )
        {
            MockUserRepository
                .GetInstagramToken( Arg.Any<string>( ) )
                .Returns( new OperationResult<string>( value, resultEnum ) );
        }
        
        protected override Dictionary<string, StringValues> SetupQueryParams( ) =>
            new Dictionary<string, StringValues>{ { Auth0IdParamKey, TestAuth0Id } };
    }
}