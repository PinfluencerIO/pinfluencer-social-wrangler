using System.Linq;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Tests.Unit.BLL.InstagramFacadeTests.GetUsersTests.ConstructedSuccessfullyTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.BLL.InstagramFacadeTests.GetUsersTests.
    ConstructedSuccessfullyTests
{
    public class When_Multiple_Users_Are_Returned : When_Constructed_Successfully
    {
        protected override void When( )
        {
            SetTwoUsers(
                "example", "123213", "Aidan Gannon", "this is my bio", 120,
                "example2", "544341", "David Gannon", "this is my second bio", 144
            );

            base.When( );

            Result = Sut.GetUsers( );
        }

        [ Test ]
        public void Then_Insta_User_Ids_Were_Valid( )
        {
            Assert.True(
                new [ ] { "123213", "544341" }.SequenceEqual( Result.Value.Select( x => x.Id ) ) );
        }

        [ Test ]
        public void Then_Insta_User_Handles_Were_Valid( )
        {
            Assert.True(
                new [ ] { "example", "example2" }.SequenceEqual(
                    Result.Value.Select( x => x.Username ) ) );
        }
    }
}