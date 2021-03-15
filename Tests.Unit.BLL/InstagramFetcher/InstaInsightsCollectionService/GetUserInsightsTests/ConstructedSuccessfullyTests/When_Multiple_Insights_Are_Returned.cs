using System;
using System.Linq;
using BLL.Models;
using BLL.Models.Insights;
using Bootstrapping.Services;
using NUnit.Framework;
using Bootstrapping.Services.Enum;
using Tests.Unit.BLL.InstagramFetcher.InstaInsightsCollectionService.GetUserInsightsTests.Shared;

namespace Tests.Unit.BLL.InstagramFetcher.InstaInsightsCollectionService.GetUserInsightsTests.ConstructedSuccessfullyTests
{
    public class When_Multiple_Insights_Are_Returned : When_Get_User_Insights_Is_Called
    {
        private OperationResult<InstaInsightsCollection> _result;

        protected override void When()
        {
            AudienceGenderAgeColleciton = GetTwoAudienceGenderAgeColleciton(
                "male",18, 24,200,
                "female",35, 44,112
            );
            AudienceGenderAgeOperationResult = OperationResultEnum.Success;
            AudienceCountryColleciton = GetTwoAudienceCountryColleciton(
                "GB", 200,
                "FR", 120
            );
            AudienceCountryOperationResult = OperationResultEnum.Success;
            ImpressionsColleciton = GetTwoImpressionsColleciton(
                new DateTime(2000,1,1), 5,
                new DateTime(2001,2,2),10
            );
            ImpressionsOperationResult = OperationResultEnum.Success;
            
            base.When();

            _result = Sut.GetUserInsights(TestId);
        }

        [Test]
        public void Then_Impressions_Count_Are_Correct()
        {
            Assert.True(new []{5,10}.SequenceEqual(_result.Value.Impressions.Select(x => x.Count)));
        }
        
        [Test]
        public void Then_Impressions_Day_Is_Correct()
        {
            Assert.True(new []{1,2}.SequenceEqual(_result.Value.Impressions.Select(x => x.Time.Day)));
        }
        
        [Test]
        public void Then_Impressions_Month_Is_Correct()
        {
            Assert.True(new []{1,2}.SequenceEqual(_result.Value.Impressions.Select(x => x.Time.Month)));
        }
        
        [Test]
        public void Then_Impressions_Year_Is_Correct()
        {
            Assert.True(new []{2000,2001}.SequenceEqual(_result.Value.Impressions.Select(x => x.Time.Year)));
        }
        
        [Test]
        public void Then_Audience_Country_Country_Code_Is_Correct()
        {
            Assert.True(new []{"GB","FR"}.SequenceEqual(_result.Value.FollowersCountries.Select(x => x.Property.CountryCode)));
        }
        
        [Test]
        public void Then_Audience_Country_Followers_Is_Correct()
        {
            Assert.True(new []{200,120}.SequenceEqual(_result.Value.FollowersCountries.Select(x => x.Count)));
        }
        
        [Test]
        public void Then_Audience_Gender_Age_Followers_Is_Correct()
        {
            Assert.True(new []{200,112}.SequenceEqual(_result.Value.FollowersGenderAges.Select(x => x.Count)));
        }
        
        [Test]
        public void Then_Audience_Gender_Age_Age_Min_Is_Correct()
        {
            Assert.True(new []{18,35}.SequenceEqual(_result.Value.FollowersGenderAges.Select(x => x.Property.AgeRange.Item1)));
        }
        
        [Test]
        public void Then_Audience_Gender_Age_Age_Max_Is_Correct()
        {
            Assert.True(new []{24,44}.SequenceEqual(_result.Value.FollowersGenderAges.Select(x => x.Property.AgeRange.Item2)));
        }
        
        [Test]
        public void Then_Audience_Gender_Age_Gender_Is_Correct()
        {
            Assert.True(new []{"male","female"}.SequenceEqual(_result.Value.FollowersGenderAges.Select(x => x.Property.Gender)));
        }
        
        [Test]
        public void Then_Result_Status_Is_Success()
        {
            Assert.AreEqual(OperationResultEnum.Success, _result.Status);
        }
    }
}