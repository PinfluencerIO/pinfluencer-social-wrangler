using System.Net;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.DAL.UserManagement.Dtos.Bubble;
using Pinf.InstaService.Tests.Unit.DAL.UserRepositoryTests.CreateInfluencer.Shared;

namespace Pinf.InstaService.Tests.Unit.DAL.UserRepositoryTests.CreateInfluencer
{
    public class When_Successful : When_Called
    {
        private OperationResultEnum _result;

        protected override void When( )
        {
            MockBubbleClient
                .Post( Arg.Any<string>( ), Arg.Any<Influencer>( ) )
                .Returns( HttpStatusCode.OK );
            _result = Sut.CreateInfluencer( DefaultInfluencer );
        }

        [ Test ]
        public void Then_Valid_Influencer_Is_Created( )
        {
            MockBubbleClient
                .Received( )
                .Post( Arg.Any<string>( ),
                    Arg.Is<Influencer>(
                        x => x.Bio == DefaultInfluencer.Bio &&
                             x.Instagram == DefaultInfluencer.InstagramHandle &&
                             x.Profile == DefaultInfluencer.User.Id &&
                             x.Age == DefaultInfluencer.Age &&
                             x.Location == DefaultInfluencer.Location ) );
        }

        [ Test ]
        public void Then_Success_Is_Returned( ) { Assert.AreEqual( OperationResultEnum.Success, _result ); }
    }
}