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
            AudienceGenderAgeColleciton = GetSingleAudienceGenderAgeColleciton("male", AgeMin, AgeMax, 2);
            AudienceGenderAgeQueryResult = QueryResultEnum.NotEmpty;
            SetDefaultAudienceCountryColleciton();
            SetDefaultImpressionsColleciton();

            base.When();
        }
    }
}