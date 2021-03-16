using NSubstitute;
using NUnit.Framework;

namespace Tests.Unit.API.Middlware.Shared
{
    public abstract class When_Auth0_Id_Found_But_Error_Occurs : When_Error_Occurs
    {
        [Test]
        public void Then_Valid_Auth0_Id_Was_Used()
        {
            MockUserRepository
                .Received()
                .GetInstagramToken(Arg.Is(TestAuth0Id));
        }
    }
}