using System.Linq;
using BLL.Models;
using Bootstrapping.Services;
using Bootstrapping.Services.Enum;
using NUnit.Framework;
using Tests.Integration.BLL.InstagramFetcher.InstaInsightsCollectionFactory.GetUserInsightsTests.Shared;

namespace Tests.Integration.BLL.InstagramFetcher.InstaInsightsCollectionFactory.GetUserInsightsTests.FailTests
{
    [TestFixture(OperationResultEnum.Failed,OperationResultEnum.Failed,OperationResultEnum.Failed)]
    [TestFixture(OperationResultEnum.Failed,OperationResultEnum.Failed,OperationResultEnum.Success)]
    [TestFixture(OperationResultEnum.Failed,OperationResultEnum.Success,OperationResultEnum.Failed)]
    [TestFixture(OperationResultEnum.Failed,OperationResultEnum.Success,OperationResultEnum.Success)]
    [TestFixture(OperationResultEnum.Success,OperationResultEnum.Failed,OperationResultEnum.Failed)]
    [TestFixture(OperationResultEnum.Success,OperationResultEnum.Failed,OperationResultEnum.Success)]
    [TestFixture(OperationResultEnum.Success,OperationResultEnum.Success,OperationResultEnum.Failed)]
    public class When_Insights_Fails_To_Be_Returned : When_Get_User_Insights_Is_Called
    {
        private OperationResult<InstaInsightsCollection> _result;

        public When_Insights_Fails_To_Be_Returned(
            OperationResultEnum countryStatus,
            OperationResultEnum genderAgeStatus,
            OperationResultEnum impressions
        )
        {
            AudienceCountryOperationResult = countryStatus;
            AudienceGenderAgeOperationResult = genderAgeStatus;
            ImpressionsOperationResult = impressions;
            
            AudienceCountryColleciton = Enumerable.Empty<InstaFollowersInsight<CountryProperty>>();
            AudienceGenderAgeColleciton = Enumerable.Empty<InstaFollowersInsight<GenderAgeProperty>>();
            ImpressionsColleciton = Enumerable.Empty<InstaImpression>();
        }

        protected override void When()
        {
            base.When();

            _result = Sut.GetUserInsights(TestId);
        }

        [Test]
        public void Then_Empty_Impressions_Are_Returned()
        {
            Assert.IsEmpty(_result.Value.Impressions);
        }
        
        [Test]
        public void Then_Empty_Audience_Gender_Age_Are_Returned()
        {
            Assert.IsEmpty(_result.Value.FollowersGenderAges);
        }
        
        [Test]
        public void Then_Empty_Audience_Country_Are_Returned()
        {
            Assert.IsEmpty(_result.Value.FollowersCountries);
        }
        
        [Test]
        public void Then_Return_Status_Is_Fail()
        {
            Assert.AreEqual(OperationResultEnum.Failed, _result.Status);
        }
    }
}