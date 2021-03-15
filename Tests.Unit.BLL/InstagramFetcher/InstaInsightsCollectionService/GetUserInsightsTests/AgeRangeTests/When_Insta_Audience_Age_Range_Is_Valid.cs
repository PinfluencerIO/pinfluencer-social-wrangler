using NUnit.Framework;
using Tests.Unit.BLL.InstagramFetcher.InstaInsightsCollectionService.GetUserInsightsTests.AgeRangeTests.Shared;

namespace Tests.Unit.BLL.InstagramFetcher.InstaInsightsCollectionService.GetUserInsightsTests.AgeRangeTests
{
    [TestFixture(13,17)]
    [TestFixture(18,24)]
    [TestFixture(25,34)]
    [TestFixture(35,44)]
    [TestFixture(45,54)]
    [TestFixture(55,64)]
    //TODO: add functionality for 65+
    public class When_Insta_Audience_Age_Range_Is_Valid : When_Age_Range_Varies
    {
        public When_Insta_Audience_Age_Range_Is_Valid(int ageMin,int ageMax)
        {
            AgeMin = ageMin;
            AgeMax = ageMax;
        }

        protected override void When()
        {
            base.When();

            Sut.GetUserInsights(TestId);
        }

        [Test]
        public void Then_ArgumentException_Was_Not_Thrown()
        {
            Assert.DoesNotThrow((() => Sut.GetUserInsights(TestId)));
        }
    }
}