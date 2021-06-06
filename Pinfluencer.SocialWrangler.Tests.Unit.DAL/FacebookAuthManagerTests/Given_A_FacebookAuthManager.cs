﻿using NSubstitute;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Factories;
using Pinfluencer.SocialWrangler.DAL.Facebook.Managers;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.FacebookAuthManagerTests
{
    //TODO: tests with factory
    public abstract class Given_A_FacebookAuthManager : DataGivenWhenThen<FacebookAuthManager>
    {
        protected const string TestToken = "654321";
        protected const string TestAuth0Id = "12345";
        protected const string Auth0IdParamKey = "auth-id";
        protected const string UserActionArgumentKey = "user";

        private IFacebookDecorator _mockFacebookDecorator;
        private IFacebookClientFactory _mockFacebookClientFactory;
        protected ITokenRepository MockTokenRepository;
        protected IFacebookDecorator MockFacebookDecorator;

        protected Result Result;

        protected override void Given( )
        {
            base.Given( );
            MockTokenRepository = Substitute.For<ITokenRepository>( );
            MockFacebookDecorator = Substitute.For<IFacebookDecorator>( );
            MockFacebookDecorator = Substitute.For<IFacebookDecorator>( );

            SUT = new FacebookAuthManager( MockTokenRepository,
                MockFacebookDecorator );
        }

        protected void SetUpUserRepository( string value, OperationResultEnum resultEnum )
        {
            MockTokenRepository
                .Get( Arg.Any<string>( ) )
                .Returns( new ObjectResult<string>( value, resultEnum ) );
        }
    }
}