using System;
using NUnit.Framework;
using Tests.Integration.BLL.InstagramFetcher.InstaInsightsCollectionFactory.GetUserInsightsTests.AgeRangeTests.Shared;

namespace Tests.Integration.BLL.InstagramFetcher.InstaInsightsCollectionFactory.GetUserInsightsTests.AgeRangeTests
{
    [TestFixture(1,2)]
    [TestFixture(18,25)]
    [TestFixture(65,100)]
    [TestFixture(0,0)]
    public class When_Insta_Audience_Age_Range_Is_Invalid : When_Age_Range_Varies
    {
        public When_Insta_Audience_Age_Range_Is_Invalid(int ageMin,int ageMax)
        {
            AgeMin = ageMin;
            AgeMax = ageMax;
        }

        protected override void When()
        {
            base.When();
            
            Assert.Catch(()=> Sut.GetUserInsights(TestId));
        }

        [Test]
        public void Then_ArgumentException_Should_Be_Thrown()
        {
            Assert.Throws<ArgumentException>(() => Sut.GetUserInsights(TestId));
        }
    }
}