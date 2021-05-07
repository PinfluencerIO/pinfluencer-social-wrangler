using System.Net;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Tests.Unit.DAL.Common.BubbleHandlerTests.Update.Shared;

namespace Pinf.InstaService.Tests.Unit.DAL.Common.BubbleHandlerTests.Update
{
    public class When_Successful : When_Called
    {
        private OperationResultEnum _result;

        protected override void When( )
        {
            MockBubbleClient
                .Patch( Arg.Any<string>( ), Arg.Any<TestDto>( ) )
                .Returns( HttpStatusCode.Created );
            _result = SutCall( );
        }

        [ Test ]
        public void Then_Success_Is_Returned( ) { Assert.AreEqual( OperationResultEnum.Success, _result ); }
        
        [ Test ]
        public void Then_Success_Event_Is_Logged( )
        {
            MockLogger
                .Received( )
                .LogInfo( Arg.Any<string>( ) );
        }
    }
}