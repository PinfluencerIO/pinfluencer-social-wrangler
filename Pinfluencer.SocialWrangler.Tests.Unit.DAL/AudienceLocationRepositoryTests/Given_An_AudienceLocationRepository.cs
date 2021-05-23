using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Repositories;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.AudienceLocationRepositoryTests
{
    public class Given_An_AudienceLocationRepository : DataGivenWhenThen<AudienceLocationRepository>
    {
        protected override void Given( )
        {
            base.Given( );
            SUT = new AudienceLocationRepository( MockBubbleDataHandler );
        }
    }
}