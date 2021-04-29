using System.Linq;
using NUnit.Framework;
using Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InstagramFacadeTests.GetUsersTests.ConstructedSuccessfullyTests.
    Shared;

namespace Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InstagramFacadeTests.GetUsersTests.
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
                new [ ] { "123213", "544341" }.SequenceEqual( Result.Value.InstaUserIdentities.Select( x => x.Id ) ) );
        }

        [ Test ]
        public void Then_Insta_User_Handles_Were_Valid( )
        {
            Assert.True(
                new [ ] { "example", "example2" }.SequenceEqual(
                    Result.Value.InstaUserIdentities.Select( x => x.Handle ) ) );
        }

        [ Test ]
        public void Then_Has_Multiple_Was_True( ) { Assert.AreEqual( true, Result.Value.HasMultiple ); }

        [ Test ]
        public void Then_Is_Empty_Was_False( ) { Assert.AreEqual( false, Result.Value.IsEmpty ); }
    }
}