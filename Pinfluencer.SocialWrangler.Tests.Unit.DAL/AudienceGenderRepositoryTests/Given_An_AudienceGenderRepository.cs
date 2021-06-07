using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Repositories;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.AudienceGenderRepositoryTests
{
    public class Given_An_AudienceGenderRepository : DataGivenWhenThen<BubbleAudienceGenderRepository>
    {
        protected override void Given( )
        {
            base.Given( );
            SUT = new BubbleAudienceGenderRepository( MockBubbleDataHandler );
        }
    }
}