using System.Net;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble;
using Pinf.InstaService.Tests.Unit.DAL.AudienceGenderRepositoryTests.Create.Shared;
using Audience = Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble.Audience;
using AudienceModel = Pinf.InstaService.Core.Models.Audience;

namespace Pinf.InstaService.Tests.Unit.DAL.AudienceGenderRepositoryTests.Create
{
    public class When_Successful : When_Called
    {
        private OperationResultEnum _result;

        protected override void When( )
        {
            MockBubbleClient
                .Post( Arg.Any<string>( ), Arg.Any<AudienceGender>( ) )
                .Returns( HttpStatusCode.Created );
            _result = Sut.Create( DefaultAudienceGenderModel );
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