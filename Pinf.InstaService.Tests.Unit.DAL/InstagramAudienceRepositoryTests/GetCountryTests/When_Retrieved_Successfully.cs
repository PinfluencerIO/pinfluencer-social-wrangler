using Facebook;
using NSubstitute;

namespace Pinf.InstaService.Tests.Unit.DAL.InstagramAudienceRepositoryTests.GetCountryTests
{
    public class When_Retrieved_Successfully : Given_A_InstagramAudienceRepository
    {
        protected override void When( )
        {
            MockFacebookClient
                .Get<JsonObject>( Arg.Any<string>( ), Arg.Any<object>( ) );
        }
    }
}