using Auth0.ManagementApi.Models;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Tests.Unit.DAL.FacebookTokenRepositoryTests.GetInstagramTokenTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.FacebookTokenRepositoryTests.GetInstagramTokenTests
{
    public class When_Token_Returned_Successfully : When_Called
    {
        private OperationResult<string> _result;

        protected override void When( )
        {
            base.When( );
            _result = SUT.Get( Id );
        }

        [ Test ]
        public void Then_Correct_Token_Is_Returned( ) { Assert.AreEqual( Token, _result.Value ); }

        [ Test ]
        public void Then_Response_Is_Successful( ) { Assert.AreEqual( OperationResultEnum.Success, _result.Status ); }

        [ Test ]
        public void Then_Success_Event_Is_Logged( )
        {
            MockLogger
                .Received( )
                .LogInfo( Arg.Any<string>( ) );
        }
    }
}