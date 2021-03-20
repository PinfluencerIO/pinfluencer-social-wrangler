using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.DAL.Instagram.Dtos;

namespace Pinf.InstaService.Tests.Unit.API.FacebookMiddlware.Shared
{
    public abstract class When_Auth0_Error_Does_Not_Occur : Given_A_FacebookMiddlware
    {
        [Test]
        public void Then_Valid_Auth0_Id_Was_Used()
        {
            MockUserRepository
                .Received()
                .GetInstagramToken(Arg.Is(TestAuth0Id));
        }

        [Test]
        public void Then_Token_Was_Inspected()
        {
            MockFacebookClient
                .Received()
                .Get("debug_token", Arg.Any<object>());
        }

        [Test]
        public void Then_Correct_Token_Was_Inspected()
        {
            MockFacebookClient
                .Received()
                .Get(Arg.Any<string>(), Arg.Is<RequestDebugTokenParams>(x => x.input_token.Equals(TestToken)));
        }

        [Test]
        public void Then_Graph_Api_Was_Called_Once()
        {
            MockFacebookClient
                .Received(1)
                .Get(Arg.Any<string>(), Arg.Any<object>());
        }

        [Test]
        public void Then_User_Repository_Was_Fetched_From_Once()
        {
            MockUserRepository
                .Received(1)
                .GetInstagramToken(Arg.Any<string>());
        }
    }
}