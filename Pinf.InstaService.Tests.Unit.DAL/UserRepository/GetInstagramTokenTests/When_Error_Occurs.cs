using System;
using System.Collections.Generic;
using Auth0.ManagementApi.Models;
using Newtonsoft.Json;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Pinf.InstaService.BLL.Core;
using Pinf.InstaService.BLL.Core.Enum;

namespace Pinf.InstaService.Tests.Unit.DAL.UserRepository.GetInstagramTokenTests
{
    public class When_Error_Occurs : Given_A_UserRepository
    {
        private OperationResult<string> _result;

        protected override void When()
        {
            MockAuth0ManagementApiConnection
                .GetAsync<User>(Arg.Any<Uri>(), Arg.Any<IDictionary<string, string>>(), Arg.Any<JsonConverter[]>())
                .Throws<AggregateException>();

            _result = Sut.GetInstagramToken(TestId);
        }

        [Test]
        public void Then_Token_Is_Empty()
        {
            Assert.AreEqual("", _result.Value);
        }

        [Test]
        public void Then_Response_Is_Fail()
        {
            Assert.AreEqual(OperationResultEnum.Failed, _result.Status);
        }
    }
}