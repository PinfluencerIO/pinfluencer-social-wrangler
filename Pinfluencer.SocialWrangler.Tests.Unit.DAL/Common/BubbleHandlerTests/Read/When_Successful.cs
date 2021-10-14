using System.Net;
using Aidan.Common.Core.Enum;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Tests.Unit.DAL.Common.BubbleHandlerTests.Read.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.Common.BubbleHandlerTests.Read
{
    public class When_Successful : When_Called
    {
        protected override void When( )
        {
            MockBubbleClient
                .Get<Dto>( Arg.Any<string>( ) )
                .Returns( ( HttpStatusCode.OK, new Dto { Id = TestId, Value = TestValue } ) );
            Result = SutCall( );
        }

        [ Test ]
        public void Then_Success_Is_Returned( ) { Assert.AreEqual( OperationResultEnum.Success, Result.Status ); }

        [ Test ]
        public void Then_Success_Event_Is_Logged( )
        {
            MockLogger
                .Received( )
                .LogInfo( Arg.Any<string>( ) );
        }

        [ Test ]
        public void Then_Mapping_Is_Valid( )
        {
            Assert.True( Result.Value.Id == TestId && Result.Value.Value == TestValue );
        }
    }
}