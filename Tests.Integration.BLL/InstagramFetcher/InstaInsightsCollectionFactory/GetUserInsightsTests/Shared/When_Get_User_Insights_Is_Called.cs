using System;
using System.Collections.Generic;
using BLL.Models;
using Bootstrapping.Services.Enum;
using Bootstrapping.Services.Repositories;
using NSubstitute;
using NUnit.Framework;

namespace Tests.Integration.BLL.InstagramFetcher.InstaInsightsCollectionFactory.GetUserInsightsTests.Shared
{
    public abstract class When_Get_User_Insights_Is_Called : Given_A_InstaInsightsCollectionFactory
    {
        protected const string TestId = "";

        protected IEnumerable<InstaFollowersInsight<CountryProperty>> AudienceCountryColleciton { get; set; }
        protected QueryResultEnum AudienceCountryQueryResult { get; set; }
        protected QueryResultEnum AudienceGenderAgeQueryResult { get; set; }
        protected IEnumerable<InstaFollowersInsight<GenderAgeProperty>> AudienceGenderAgeColleciton { get; set; }

        protected override void When()
        {
            MockAudienceInsightsRepository
                .GetGenderAge(Arg.Any<string>())
                .Returns(new QueryResult<IEnumerable<InstaFollowersInsight<GenderAgeProperty>>>(
                        AudienceGenderAgeColleciton,AudienceGenderAgeQueryResult
                    )
                );
            MockAudienceInsightsRepository
                .GetCountry(Arg.Any<string>())
                .Returns(
                    new QueryResult<IEnumerable<InstaFollowersInsight<CountryProperty>>>(
                        AudienceCountryColleciton, AudienceCountryQueryResult
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
    }
}