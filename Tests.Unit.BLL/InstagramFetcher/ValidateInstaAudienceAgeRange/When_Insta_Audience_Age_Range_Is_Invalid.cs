using NUnit.Framework;
using Tests.Unit.BLL.InstagramFetcher.ValidateInstaAudienceAgeRange.Shared;

namespace Tests.Unit.BLL.InstagramFetcher.ValidateInstaAudienceAgeRange
{
    [TestFixture(1,2)]
    [TestFixture(18,25)]
    [TestFixture(65,100)]
    [TestFixture(0,0)]
    public class When_Insta_Audience_Age_Range_Is_Invalid : Given_A_ValidateInstaAudienceAgeRange
    {
        public When_Insta_Audience_Age_Range_Is_Invalid(int ageMin,int ageMax)
        {
            AgeMin = ageMin;
            AgeMax = ageMax;
        }

        [Test]
        public void Then_Validate_Returns_False()
        {
            Assert.False(Result);
        }
    }
}