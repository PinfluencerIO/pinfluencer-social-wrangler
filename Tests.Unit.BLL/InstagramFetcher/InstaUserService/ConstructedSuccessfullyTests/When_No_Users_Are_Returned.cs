﻿using System.Linq;
using BLL.Models.InstaUser;
using Bootstrapping.Services;
using NUnit.Framework;
using Tests.Unit.BLL.InstagramFetcher.InstaUserService.ConstructedSuccessfullyTests.Shared;

namespace Tests.Unit.BLL.InstagramFetcher.InstaUserService.ConstructedSuccessfullyTests
{
    public class When_No_Users_Are_Returned : When_Constructed_Successfully
    {
        protected override void When()
        {
            InstaUserCollection = Enumerable.Empty<InstaUser>();

            base.When();

            Result = Sut.GetAll();
        }
        
        [Test]
        public void Then_Insta_User_Array_Is_Empty_Valid()
        {
            Assert.IsEmpty(Result.Value.InstaUserIdentities);
        }

        [Test]
        public void Then_Has_Multiple_Was_False()
        {
            Assert.AreEqual(false,Result.Value.HasMultiple);
        }
        
        [Test]
        public void Then_Is_Empty_Was_True()
        {
            Assert.AreEqual(true,Result.Value.IsEmpty);
        }
    }
}