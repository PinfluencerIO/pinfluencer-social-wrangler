using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Repositories;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InfluencerRepositoryTests
{
    public class Given_A_InfluencerRepository : DataGivenWhenThen<InfluencerRepository>
    {
        protected override void Given( )
        {
            base.Given( );
            SUT = new InfluencerRepository( MockBubbleDataHandler );
        }
    }
}