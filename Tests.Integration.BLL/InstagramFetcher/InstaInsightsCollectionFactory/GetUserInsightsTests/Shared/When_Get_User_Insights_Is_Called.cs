using System;
using System.Collections.Generic;
using BLL.Models;
using Bootstrapping.Services.Enum;
using Bootstrapping.Services.Repositories;
using NSubstitute;

namespace Tests.Integration.BLL.InstagramFetcher.InstaInsightsCollectionFactory.GetUserInsightsTests.Shared
{
    public abstract class When_Get_User_Insights_Is_Called : Given_A_InstaInsightsCollectionFactory
    {
        protected const string TestId = "";
        
        protected QueryResultEnum AudienceGenderAgeQueryResult { get; set; }
        protected IEnumerable<InstaFollowersInsight<GenderAgeProperty>> AudienceGenderAgeColleciton { get; set; }

        protected override void When()
        {
            MockAudienceInsightsRepository
                .GetGenderAge(Arg.Any<string>())
                .Returns(new QueryResult<IEnumerable<InstaFollowersInsight<GenderAgeProperty>>>
                    (AudienceGenderAgeColleciton,AudienceGenderAgeQueryResult)
                );
        }
    }
}