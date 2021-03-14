using System;
using System.Collections.Generic;
using BLL.Models;
using Bootstrapping.Services.Enum;
using Bootstrapping.Services.Repositories;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Tests.Unit.BLL.InstagramFetcher.InstaInsightsCollectionFactory.GetUserInsightsTests
{
    [TestFixture(1,2)]
    public class When_Insta_Audience_Age_Range_Is_Invalid : Given_A_InstaInsightsCollectionFactory
    {
        private readonly int _ageMin;
        private readonly int _ageMax;

        public When_Insta_Audience_Age_Range_Is_Invalid(int ageMin,int ageMax)
        {
            _ageMin = ageMin;
            _ageMax = ageMax;
        }
        
        protected override void When()
        {
            MockAudienceInsightsRepository
                .GetGenderAge(Arg.Any<string>())
                .Returns(new QueryResult<IEnumerable<InstaFollowersInsight<GenderAgeProperty>>>
                    (new [] { new InstaFollowersInsight<GenderAgeProperty>(
                            new GenderAgeProperty("male",new Tuple<int, int>(_ageMin,_ageMax)),
                            2)
                        },
                    QueryResultEnum.NotEmpty
                    )
                );
        }

        [Test]
        public void Then_ArgumentException_Should_Be_Thrown()
        {
            Assert.Throws<ArgumentException>(() => Sut.GetUserInsights(""));
        }
    }
}