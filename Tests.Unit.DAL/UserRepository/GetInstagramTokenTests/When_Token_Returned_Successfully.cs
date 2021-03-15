using Auth0.ManagementApi.Models;

namespace Tests.Unit.DAL.UserRepository.GetInstagramTokenTests
{
    public class When_Token_Returned_Successfully : Given_A_UserRepository
    {
        protected override void When()
        {
            TestUser = new User
            {
                Identities = new Identity[]
                {
                    new Identity
                    {
                        AccessToken = "1234567"
                    }
                }
            };
            
            base.When();

            Sut.GetInstagramToken(TestId);
        }
    }
}