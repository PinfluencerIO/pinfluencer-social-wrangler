using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Repositories;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.AudienceRepositoryTests
{
    public class Given_An_AudienceRepository : DataGivenWhenThen<BubbleAudienceRepository>
    {
        protected override void Given( )
        {
            base.Given( );
            SUT = new BubbleAudienceRepository( MockBubbleDataHandler );
        }
    }
}