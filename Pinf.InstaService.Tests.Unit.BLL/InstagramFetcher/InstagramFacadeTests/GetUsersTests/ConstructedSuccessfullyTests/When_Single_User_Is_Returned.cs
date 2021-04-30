﻿using System.Linq;
using NUnit.Framework;
using Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InstagramFacadeTests.GetUsersTests.ConstructedSuccessfullyTests.
    Shared;

namespace Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InstagramFacadeTests.GetUsersTests.
    ConstructedSuccessfullyTests
{
    public class When_Single_User_Is_Returned : When_Constructed_Successfully
    {
        protected override void When( )
        {
            SetSingleUser( "example", "123213", "Aidan Gannon", "this is my bio", 120 );

            base.When( );

            Result = Sut.GetUsers( );
        }

        [ Test ]
        public void Then_Insta_User_Id_Was_Valid( )
        {
            Assert.AreEqual( "123213", Result.Value.First( ).Id );
        }

        [ Test ]
        public void Then_Insta_User_Handle_Was_Valid( )
        {
            Assert.AreEqual( "example", Result.Value.First( ).Handle );
        }
    }
}