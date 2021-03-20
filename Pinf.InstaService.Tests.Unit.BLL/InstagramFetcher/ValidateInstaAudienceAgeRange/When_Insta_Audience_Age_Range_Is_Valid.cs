using NUnit.Framework;
using Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.ValidateInstaAudienceAgeRange.Shared;

namespace Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.ValidateInstaAudienceAgeRange
{
    [TestFixture(13, 17)]
    [TestFixture(18, 24)]
    [TestFixture(25, 34)]
    [TestFixture(35, 44)]
    [TestFixture(45, 54)]
    [TestFixture(55, 64)]
    //TODO: add functionality for 65+
    public class When_Insta_Audience_Age_Range_Is_Valid : Given_A_ValidateInstaAudienceAgeRange
    {
        public When_Insta_Audience_Age_Range_Is_Valid(int ageMin, int ageMax)
        {
            AgeMin = ageMin;
            AgeMax = ageMax;
        }

        [Test]
        public void Then_Validate_Returns_True()
        {
            Assert.True(Result);
        }
    }
}