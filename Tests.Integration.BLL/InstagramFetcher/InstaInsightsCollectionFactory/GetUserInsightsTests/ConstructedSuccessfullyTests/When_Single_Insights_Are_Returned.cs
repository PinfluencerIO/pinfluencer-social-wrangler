using System;
using System.Linq;
using BLL.Models;
using Bootstrapping.Services;
using NUnit.Framework;
using Tests.Integration.BLL.InstagramFetcher.InstaInsightsCollectionFactory.GetUserInsightsTests.Shared;
using Bootstrapping.Services.Enum;

namespace Tests.Integration.BLL.InstagramFetcher.InstaInsightsCollectionFactory.GetUserInsightsTests.ConstructedSuccessfullyTests
{
    [TestFixture]
    public class When_Single_Insights_Are_Returned : When_Get_User_Insights_Is_Called
    {
        private OperationResult<InstaInsightsCollection> _result;

        protected override void When()
        {
            AudienceGenderAgeColleciton = GetSingleAudienceGenderAgeColleciton("male",18, 24,5);
            AudienceGenderAgeOperationResult = OperationResultEnum.Success;
            AudienceCountryColleciton = GetSingleAudienceCountryColleciton("GB", 2);
            AudienceCountryOperationResult = OperationResultEnum.Success;
            ImpressionsColleciton = GetSingleImpressionsColleciton(new DateTime(2000,1,1), 5);
            ImpressionsOperationResult = OperationResultEnum.Success;
            
            base.When();

            _result = Sut.GetUserInsights(TestId);
        }

        [Test]
        public void Then_Impressions_Count_Are_Correct()
        {
            Assert.AreEqual(5, _result.Value.Impressions.First().Count);
        }
        
        [Test]
        public void Then_Impressions_Day_Is_Correct()
        {
            Assert.AreEqual(1, _result.Value.Impressions.First().Time.Day);
        }
        
        [Test]
        public void Then_Impressions_Month_Is_Correct()
        {
            Assert.AreEqual(1, _result.Value.Impressions.First().Time.Month);
        }
        
        [Test]
        public void Then_Impressions_Year_Is_Correct()
        {
            Assert.AreEqual(2000, _result.Value.Impressions.First().Time.Year);
        }
        
        [Test]
        public void Then_Audience_Country_Country_Code_Is_Correct()
        {
            Assert.AreEqual("GB", _result.Value.FollowersCountries.First().Property.CountryCode);
        }
        
        [Test]
        public void Then_Audience_Country_Followers_Is_Correct()
        {
            Assert.AreEqual(2, _result.Value.FollowersCountries.First().Count);
        }
        
        [Test]
        public void Then_Audience_Gender_Age_Followers_Is_Correct()
        {
            Assert.AreEqual(5, _result.Value.FollowersGenderAges.First().Count);
        }
        
        [Test]
        public void Then_Audience_Gender_Age_Age_Min_Is_Correct()
        {
            Assert.AreEqual(18, _result.Value.FollowersGenderAges.First().Property.AgeRange.Item1);
        }
        
        [Test]
        public void Then_Audience_Gender_Age_Age_Max_Is_Correct()
        {
            Assert.AreEqual(24, _result.Value.FollowersGenderAges.First().Property.AgeRange.Item2);
        }
        
        [Test]
        public void Then_Audience_Gender_Age_Gender_Is_Correct()
        {
            Assert.AreEqual("male", _result.Value.FollowersGenderAges.First().Property.Gender);
        }
        
        [Test]
        public void Then_Result_Status_Is_Success()
        {
            Assert.AreEqual(OperationResultEnum.Success, _result.Status);
        }
    }
}