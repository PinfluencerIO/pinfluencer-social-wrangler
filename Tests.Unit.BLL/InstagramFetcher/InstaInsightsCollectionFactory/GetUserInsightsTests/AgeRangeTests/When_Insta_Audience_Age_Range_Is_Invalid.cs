using System;
using System.Collections.Generic;
using BLL.Models;
using Bootstrapping.Services.Enum;
using Bootstrapping.Services.Repositories;
using NSubstitute;
using NUnit.Framework;
using Tests.Unit.BLL.InstagramFetcher.InstaInsightsCollectionFactory.GetUserInsightsTests.AgeRangeTests.Shared;

namespace Tests.Unit.BLL.InstagramFetcher.InstaInsightsCollectionFactory.GetUserInsightsTests.AgeRangeTests
{
    [TestFixture(1,2)]
    public class When_Insta_Audience_Age_Range_Is_Invalid : When_Age_Range_Varies
    {
        public When_Insta_Audience_Age_Range_Is_Invalid(int ageMin,int ageMax)
        {
            AgeMin = ageMin;
            AgeMax = ageMax;
        }

        [Test]
        public void Then_ArgumentException_Should_Be_Thrown()
        {
            Assert.Throws<ArgumentException>(() => Sut.GetUserInsights(TestId));
        }
    }
}