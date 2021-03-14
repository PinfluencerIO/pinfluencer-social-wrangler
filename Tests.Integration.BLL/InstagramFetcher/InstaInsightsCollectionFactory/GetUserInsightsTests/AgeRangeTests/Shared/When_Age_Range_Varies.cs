using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Models;
using Bootstrapping.Services.Enum;
using Bootstrapping.Services.Repositories;
using Tests.Integration.BLL.InstagramFetcher.InstaInsightsCollectionFactory.GetUserInsightsTests.Shared;

namespace Tests.Integration.BLL.InstagramFetcher.InstaInsightsCollectionFactory.GetUserInsightsTests.AgeRangeTests.Shared
{
    public abstract class When_Age_Range_Varies : When_Get_User_Insights_Is_Called
    {
        protected int AgeMin;
        protected int AgeMax;

        protected override void When()
        {
            AudienceGenderAgeColleciton = new[]
            {
                new InstaFollowersInsight<GenderAgeProperty>(
                    new GenderAgeProperty(
                        "male", 
                        new Tuple<int, int>(
                            AgeMin,
                            AgeMax
                        )
                    ),
                    2
                )
            };
            AudienceGenderAgeQueryResult = QueryResultEnum.NotEmpty;
            AudienceCountryColleciton = Enumerable.Empty<InstaFollowersInsight<CountryProperty>>();
            AudienceCountryQueryResult = QueryResultEnum.Empty;
            
            base.When();
        }
    }
}