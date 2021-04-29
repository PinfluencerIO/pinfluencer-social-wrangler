using System.Net;
using NSubstitute;
using Pinf.InstaService.Core.Models.User;
using Pinf.InstaService.Tests.Unit.DAL.UserRepositoryTests.CreateInfluencer.Shared;
using Influencer = Pinf.InstaService.DAL.UserManagement.Dtos.Bubble.Influencer;

namespace Pinf.InstaService.Tests.Unit.DAL.UserRepositoryTests.CreateInfluencer
{
    public class When_Http_Error_Occurs : When_Error_Occurs
    { 
        protected override void When( )
        {
            MockBubbleClient
                .Post( Arg.Any<string>( ), Arg.Any<Influencer>(  ) )
                .Returns( HttpStatusCode.BadRequest );
            Result = Sut.CreateInfluencer( DefaultInfluencer );
        }
    }
}