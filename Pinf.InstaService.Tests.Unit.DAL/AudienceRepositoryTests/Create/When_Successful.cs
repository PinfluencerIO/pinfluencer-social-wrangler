using System.Net;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Models;
using Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble;
using Pinf.InstaService.Tests.Unit.DAL.AudienceRepositoryTests.Create.Shared;
using Audience = Pinf.InstaService.Core.Models.Audience;

namespace Pinf.InstaService.Tests.Unit.DAL.AudienceRepositoryTests.Create
{
    public class When_Successful : When_Called
    {
        private OperationResultEnum _result;

        protected override void When( )
        {
            MockBubbleClient
                .Post( Arg.Any<string>( ), Arg.Any<Influencer>( ) )
                .Returns( HttpStatusCode.Created );
            _result = Sut.Create( new Audience( ) );
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