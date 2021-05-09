using Pinf.InstaService.Crosscutting.NUnit.PinfluencerExtensions;
using Pinf.InstaService.DAL.Pinfluencer.Repositories;

namespace Pinf.InstaService.Tests.Unit.DAL.AudienceAgeRepositoryTests
{
    public class Given_An_AudienceAgeRepository : DataGivenWhenThen<AudienceAgeRepository>
    {
        protected override void Given( )
        {
            base.Given( );
            Sut = new AudienceAgeRepository( MockBubbleDataHandler );
        }
    }
}