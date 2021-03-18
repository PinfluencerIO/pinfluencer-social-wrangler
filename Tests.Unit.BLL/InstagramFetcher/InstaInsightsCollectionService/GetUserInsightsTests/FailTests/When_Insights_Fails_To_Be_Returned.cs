using System.Linq;
using BLL.Models.Insights;
using Bootstrapping.Services;
using Bootstrapping.Services.Enum;
using NUnit.Framework;
using Tests.Unit.BLL.InstagramFetcher.InstaInsightsCollectionService.GetUserInsightsTests.Shared;

namespace Tests.Unit.BLL.InstagramFetcher.InstaInsightsCollectionService.GetUserInsightsTests.FailTests
{
    public class When_Insights_Fails_To_Be_Returned : When_Get_User_Insights_Is_Called
    {
        private OperationResult<InstaInsightsCollection> _result;

        protected override void When()
        {
            ImpressionsOperationResult = OperationResultEnum.Failed;

            ImpressionsColleciton = Enumerable.Empty<InstaImpression>();

            base.When();

            _result = Sut.GetUserInsights(TestId);
        }

        [Test]
        public void Then_Empty_Impressions_Are_Returned()
        {
            Assert.IsEmpty(_result.Value.Impressions);
        }

        [Test]
        public void Then_Return_Status_Is_Fail()
        {
            Assert.AreEqual(OperationResultEnum.Failed, _result.Status);
        }
    }
}