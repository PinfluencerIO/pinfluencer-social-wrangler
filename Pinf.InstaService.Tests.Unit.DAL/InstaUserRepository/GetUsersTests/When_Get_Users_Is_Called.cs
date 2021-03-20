using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.DAL.Instagram.Dtos;

namespace Pinf.InstaService.Tests.Unit.DAL.InstaUserRepository.GetUsersTests
{
    public abstract class When_Get_Users_Is_Called : Given_A_InstaUserRepository
    {
        private dynamic[] _response;

        protected override void When()
        {
            MockFacebookClient
                .Get(Arg.Any<string>(), Arg.Any<object>())
                .Returns(new
                {
                    data = _response
                });
        }

        protected void SetSingleInsta(string id, string username, string name, string bio, int followers)
        {
            _response = new[]
            {
                SetInsta(id, username, name, bio, followers)
            };
        }

        protected void SetTwoPagesAndOneInsta(string id, string username, string name, string bio, int followers)
        {
            _response = new[]
            {
                SetInsta(id, username, name, bio, followers),
                new {id = "page_id"}
            };
        }

        private static dynamic SetInsta(string id, string username, string name, string bio, int followers)
        {
            return new
            {
                instagram_business_account = new
                {
                    id, username, name, biography = bio, followers_count = followers
                }
            };
        }

        protected void SetEmptyPage()
        {
            _response = new dynamic[]
            {
                new {id = "123123"},
                new {id = "321322"}
            };
        }

        protected void SetTwoInsta(
            string id1,
            string username1,
            string name1,
            string bio1,
            int followers1,
            string id2,
            string username2,
            string name2,
            string bio2,
            int followers2
        )
        {
            _response = new[]
            {
                SetInsta(id1, username1, name1, bio1, followers1),
                SetInsta(id2, username2, name2, bio2, followers2)
            };
        }

        [Test]
        public void Then_Get_Users_Is_Called_Once()
        {
            MockFacebookClient
                .Received(1)
                .Get(Arg.Any<string>(), Arg.Any<object>());
        }

        [Test]
        public void Then_Valid_Endpoint_Was_Hit()
        {
            MockFacebookClient
                .Received()
                .Get(Arg.Is("me/accounts"), Arg.Any<object>());
        }

        [Test]
        public void Then_Valid_Fields_Were_Sent()
        {
            MockFacebookClient
                .Received()
                .Get(Arg.Any<string>(),
                    Arg.Is<RequestFields>(x =>
                        x.fields == "instagram_business_account{id,username,name,biography,followers_count}"));
        }
    }
}