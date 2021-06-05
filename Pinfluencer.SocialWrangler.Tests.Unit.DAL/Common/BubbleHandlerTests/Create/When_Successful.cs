using System.Net;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Tests.Unit.DAL.Common.BubbleHandlerTests.Create.Shared;
using AudienceModel = Pinfluencer.SocialWrangler.Core.Models.Audience;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.Common.BubbleHandlerTests.Create
{
    public class When_Successful : When_Called
    {
        private OperationResultEnum _result;

        protected override void When( )
        {
            MockBubbleClient
                .Post( Arg.Any<string>( ), Arg.Any<Dto>( ) )
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