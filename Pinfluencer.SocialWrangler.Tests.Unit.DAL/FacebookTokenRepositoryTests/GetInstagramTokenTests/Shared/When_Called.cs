using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.FacebookTokenRepositoryTests.GetInstagramTokenTests.Shared
{
    public abstract class When_Called : Given_A_FacebookTokenRepository
    {
        protected const string Id = "1234";
        protected const string Token = "1234567";

        protected override void When( )
        {
            MockAuthServiceManagementClientDecorator
                .GetIdentityToken( Arg.Any<string>( ) )
                .Returns( Token );
        }

        [ Test ]
        public void Then_Get_Token_Is_Called_Once( )
        {
            MockAuthServiceManagementClientDecorator
                .Received( 1 )
                .GetIdentityToken( Arg.Any<string>( ) );
        }

        [ Test ]
        public void Then_Valid_User_Is_Retrieved( )
        {
            MockAuthServiceManagementClientDecorator
                .Received( )
                .GetIdentityToken( Id );
        }
    }
}