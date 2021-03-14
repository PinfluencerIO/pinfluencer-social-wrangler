using System;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Tests.Unit.BLL.InstagramFetcher.InstaInsightsCollectionFactory.GetUserInsightsTests
{
    public class When_Insta_Audience_Age_Range_Is_Invalid : Given_A_InstaInsightsCollectionFactory
    {
        public void Then_ArgumentException_Should_Be_Thrown()
        {
            Assert.Throws<ArgumentException>(() => Sut.GetUserInsights(""));
        }
    }
}