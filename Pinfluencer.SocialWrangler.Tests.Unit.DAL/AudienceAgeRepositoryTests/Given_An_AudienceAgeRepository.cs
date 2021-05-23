using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Repositories;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.AudienceAgeRepositoryTests
{
    public class Given_An_AudienceAgeRepository : DataGivenWhenThen<AudienceAgeRepository>
    {
        protected override void Given( )
        {
            base.Given( );
            SUT = new AudienceAgeRepository( MockBubbleDataHandler );
        }
    }
}