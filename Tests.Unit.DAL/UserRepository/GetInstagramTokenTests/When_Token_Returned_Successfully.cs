using Auth0.ManagementApi.Models;
using Bootstrapping.Services;
using Bootstrapping.Services.Enum;
using NUnit.Framework;

namespace Tests.Unit.DAL.UserRepository.GetInstagramTokenTests
{
    public class When_Token_Returned_Successfully : Given_A_UserRepository
    {
        private OperationResult<string> _result;

        protected override void When()
        {
            TestUser = new User
            {
                Identities = new[]
                {
                    new Identity
                    {
                        AccessToken = "1234567"
                    }
                }
            };

            base.When();

            _result = Sut.GetInstagramToken(TestId);
        }

        [Test]
        public void Then_Correct_Token_Is_Returned()
        {
            Assert.AreEqual("1234567", _result.Value);
        }

        [Test]
        public void Then_Response_Is_Successful()
        {
            Assert.AreEqual(OperationResultEnum.Success, _result.Status);
        }
    }
}