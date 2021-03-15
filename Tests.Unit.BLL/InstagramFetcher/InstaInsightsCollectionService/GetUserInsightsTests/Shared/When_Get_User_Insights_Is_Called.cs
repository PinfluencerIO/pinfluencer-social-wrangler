using System;
using System.Collections.Generic;
using BLL.Models;
using BLL.Models.Insights;
using Bootstrapping.Services;
using Bootstrapping.Services.Enum;
using NSubstitute;
using NUnit.Framework;

namespace Tests.Unit.BLL.InstagramFetcher.InstaInsightsCollectionService.GetUserInsightsTests.Shared
{
    public abstract class When_Get_User_Insights_Is_Called : Given_A_InstaInsightsCollectionService
    {
        protected const string TestId = "";

        protected OperationResultEnum ImpressionsOperationResult { get; set; }
        protected IEnumerable<InstaImpression> ImpressionsColleciton { get; set; }
        protected IEnumerable<InstaFollowersInsight<CountryProperty>> AudienceCountryColleciton { get; set; }
        protected OperationResultEnum AudienceCountryOperationResult { get; set; }
        protected OperationResultEnum AudienceGenderAgeOperationResult { get; set; }
        protected IEnumerable<InstaFollowersInsight<GenderAgeProperty>> AudienceGenderAgeColleciton { get; set; }

        protected override void When()
        {
            MockAudienceInsightsRepository
                .GetGenderAge(Arg.Any<string>())
                .Returns(new OperationResult<IEnumerable<InstaFollowersInsight<GenderAgeProperty>>>(
                        AudienceGenderAgeColleciton,AudienceGenderAgeOperationResult
                    )
                );
            MockAudienceInsightsRepository
                .GetCountry(Arg.Any<string>())
                .Returns(
                    new OperationResult<IEnumerable<InstaFollowersInsight<CountryProperty>>>(
                        AudienceCountryColleciton, AudienceCountryOperationResult
                    )
                );
            MockImpressionsInsightsRepository
                .GetImpressions(Arg.Any<string>())
                .Returns(
                    new OperationResult<IEnumerable<InstaImpression>>(
                        ImpressionsColleciton, ImpressionsOperationResult
                    )
                );
        }

        [Test]
        public void Then_Get_Gender_Age_Audience_Insights_Was_Called_Once()
        {
            MockAudienceInsightsRepository
                .Received(1)
                .GetGenderAge(Arg.Any<string>());
        }
        
        [Test]
        public void Then_Get_Country_Audience_Insights_Was_Called_Once()
        {
            MockAudienceInsightsRepository
                .Received(1)
                .GetCountry(Arg.Any<string>());
        }
        
        [Test]
        public void Then_Get_Gender_Age_Audience_Insights_Was_Called_With_Correct_Id()
        {
            MockAudienceInsightsRepository
                .Received()
                .GetGenderAge(Arg.Is(TestId));
        }
        
        [Test]
        public void Then_Get_Country_Audience_Insights_Was_Called_With_Correct_Id()
        {
            MockAudienceInsightsRepository
                .Received()
                .GetCountry(Arg.Is(TestId));
        }
        
        [Test]
        public void Then_Get_Impressions_Insights_Was_Called_Once()
        {
            MockImpressionsInsightsRepository
                .Received(1)
                .GetImpressions(Arg.Any<string>());
        }
        
        [Test]
        public void Then_Get_Impressions_Insights_Was_Called_With_Correct_Id()
        {
            MockImpressionsInsightsRepository
                .Received()
                .GetImpressions(Arg.Is(TestId));
        }
        
        protected IEnumerable<InstaImpression> GetSingleImpressionsColleciton(DateTime date,int impressions)
        {
            return new []
            {
                new InstaImpression(date,impressions)
            };
        }
        
        protected IEnumerable<InstaImpression> GetTwoImpressionsColleciton(
            DateTime date1,
            int impressions1,
            DateTime date2,
            int impressions2
        )
        {
            return new []
            {
                new InstaImpression(date1,impressions1),
                new InstaImpression(date2,impressions2)
            };
        }
        
        protected void SetDefaultImpressionsColleciton()
        {
            ImpressionsColleciton = GetSingleImpressionsColleciton(new DateTime(2000,1,1),5);
            ImpressionsOperationResult = OperationResultEnum.Success;
        }

        protected IEnumerable<InstaFollowersInsight<CountryProperty>> GetSingleAudienceCountryColleciton(string country,int followerCount)
        {
            return new []
            {
                new InstaFollowersInsight<CountryProperty>(new CountryProperty(country),followerCount)
            };
        }
        
        protected IEnumerable<InstaFollowersInsight<CountryProperty>> GetTwoAudienceCountryColleciton(
            string country1,
            int followerCount1,
            string country2,
            int followerCount2
        )
        {
            return new []
            {
                new InstaFollowersInsight<CountryProperty>(new CountryProperty(country1),followerCount1),
                new InstaFollowersInsight<CountryProperty>(new CountryProperty(country2),followerCount2)
            };
        }
        
        protected void SetDefaultAudienceCountryColleciton()
        {
            AudienceCountryColleciton = GetSingleAudienceCountryColleciton("GB", 5);
            AudienceCountryOperationResult = OperationResultEnum.Success;
        }
        
        protected IEnumerable<InstaFollowersInsight<GenderAgeProperty>> GetSingleAudienceGenderAgeColleciton(string gender,int ageMin,int ageMax,int followerCount)
        {
            return new InstaFollowersInsight<GenderAgeProperty>[]
            {
                new InstaFollowersInsight<GenderAgeProperty>(new GenderAgeProperty(gender,new Tuple<int, int>(ageMin,ageMax)),followerCount)
            };
        }
        
        protected IEnumerable<InstaFollowersInsight<GenderAgeProperty>> GetTwoAudienceGenderAgeColleciton(
            string gender1,
            int ageMin1,
            int ageMax1,
            int followerCount1,
            string gender2,
            int ageMin2,
            int ageMax2,
            int followerCount2
        )
        {
            return new []
            {
                new InstaFollowersInsight<GenderAgeProperty>(new GenderAgeProperty(gender1,new Tuple<int, int>(ageMin1,ageMax1)),followerCount1),
                new InstaFollowersInsight<GenderAgeProperty>(new GenderAgeProperty(gender2,new Tuple<int, int>(ageMin2,ageMax2)),followerCount2)
            };
        }
        
        protected void SetDefaultAudienceGenderAgeColleciton()
        {
            AudienceGenderAgeColleciton = GetSingleAudienceGenderAgeColleciton("male", 18, 24, 5);
            AudienceGenderAgeOperationResult = OperationResultEnum.Success;
        }
    }
}