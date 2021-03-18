using System.Collections.Generic;
using BLL.Models.Insights;
using Bootstrapping.Services;
using Bootstrapping.Services.Enum;
using Facebook;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;

namespace Tests.Unit.DAL.InstaImpressionsRepository.GetImpressionsTests
{
    public class When_Facebook_Graph_Error_Occurs : When_Get_Impressions_Was_Called
    {
        private OperationResult<IEnumerable<InstaImpression>> _result;

        protected override void When()
        {
            MockFacebookClient
                .Get(Arg.Any<string>(), Arg.Any<object>())
                .Throws<FacebookOAuthException>();

            base.When();

            _result = Sut.GetImpressions(TestId);
        }

        [Test]
        public void Then_The_Response_Is_Empty()
        {
            Assert.IsEmpty(_result.Value);
        }

        [Test]
        public void Then_The_Status_Is_Fail()
        {
            Assert.AreEqual(OperationResultEnum.Failed, _result.Status);
        }
    }
}