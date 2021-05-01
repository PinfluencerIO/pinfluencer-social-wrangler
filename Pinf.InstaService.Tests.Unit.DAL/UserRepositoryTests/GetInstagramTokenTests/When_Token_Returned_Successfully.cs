using Auth0.ManagementApi.Models;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Tests.Unit.DAL.UserRepositoryTests.GetInstagramTokenTests.Shared;

namespace Pinf.InstaService.Tests.Unit.DAL.UserRepositoryTests.GetInstagramTokenTests
{
    public class When_Token_Returned_Successfully : When_Called
    {
        private OperationResult<string> _result;

        protected override void When( )
        {
            TestUser = new User
            {
                Identities = new [ ]
                {
                    new Identity
                    {
                        AccessToken = "1234567"
                    }
                }
            };

            base.When( );

            _result = Sut.GetInstagramToken( TestId );
        }

        [ Test ]
        public void Then_Correct_Token_Is_Returned( ) { Assert.AreEqual( "1234567", _result.Value ); }

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