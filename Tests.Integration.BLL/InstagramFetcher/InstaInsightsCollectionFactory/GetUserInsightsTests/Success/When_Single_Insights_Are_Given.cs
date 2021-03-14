using System;
using BLL.InstagramFetcher;
using BLL.Models;
using Bootstrapping.Services.Enum;
using NUnit.Framework;
using Tests.Integration.BLL.InstagramFetcher.InstaInsightsCollectionFactory.GetUserInsightsTests.Shared;

namespace Tests.Integration.BLL.InstagramFetcher.InstaInsightsCollectionFactory.GetUserInsightsTests.Success
{
    [TestFixture]
    public class When_Single_Insights_Are_Given : When_Get_User_Insights_Is_Called
    {
        private OperationResult<InstaInsightsCollection> _result;

        protected override void When()
        {
            AudienceGenderAgeColleciton = new[]
            {
                new InstaFollowersInsight<GenderAgeProperty>(
                    new GenderAgeProperty(
                        "male", new Tuple<int, int>(18, 24)
                    ),
                    2
                )
            };
            AudienceGenderAgeQueryResult = QueryResultEnum.NotEmpty;
            AudienceCountryColleciton = new[]
            {
                new InstaFollowersInsight<CountryProperty>(
                    new CountryProperty(
                        "GB"
                    ),
                    2
                )
            };
            AudienceCountryQueryResult = QueryResultEnum.NotEmpty;
            
            base.When();
            
            _result = Sut.GetUserInsights(TestId);
        }

        [Test]
        public void Then_Insights_Are_Constructed_Correctly()
        {
        }
    }
}