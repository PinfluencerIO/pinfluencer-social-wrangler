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
                .Returns( HttpStatusCode.Created );
            _result = Sut.CreateInfluencer( GetDefaultInfluencer() );
        }

        [ Test ]
        public void Then_Valid_Influencer_Is_Created( )
        {
            MockBubbleClient
                .Received( )
                .Post( Arg.Any<string>( ),
                    Arg.Is<Influencer>(
                        x => x.Bio == GetDefaultInfluencer().Bio &&
                             x.Instagram == GetDefaultInfluencer().InstagramHandle &&
                             x.Profile == GetDefaultInfluencer().User.Id &&
                             x.Age == GetDefaultInfluencer().Age &&
                             x.Location == GetDefaultInfluencer().Location ) );
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