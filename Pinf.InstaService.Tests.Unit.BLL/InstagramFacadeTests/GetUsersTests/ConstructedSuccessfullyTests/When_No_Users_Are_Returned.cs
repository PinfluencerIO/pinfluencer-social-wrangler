using System.Linq;
using NUnit.Framework;
using Pinf.InstaService.Core.Models.InstaUser;
using Pinf.InstaService.Tests.Unit.BLL.InstagramFacadeTests.GetUsersTests.ConstructedSuccessfullyTests.Shared;

namespace Pinf.InstaService.Tests.Unit.BLL.InstagramFacadeTests.GetUsersTests.
    ConstructedSuccessfullyTests
{
    public class When_No_Users_Are_Returned : When_Constructed_Successfully
    {
        protected override void When( )
        {
            InstaUserCollection = Enumerable.Empty<InstaUser>( );

            base.When( );

            Result = Sut.GetUsers( );
        }

        [ Test ]
        public void Then_Insta_User_Array_Is_Empty_Valid( ) { Assert.IsEmpty( Result.Value ); }
    }
}