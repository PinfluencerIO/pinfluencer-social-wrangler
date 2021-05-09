using Pinf.InstaService.Crosscutting.NUnit.PinfluencerExtensions;
using Pinf.InstaService.DAL.Pinfluencer.Repositories;

namespace Pinf.InstaService.Tests.Unit.DAL.AudienceLocationRepositoryTests
{
    public class Given_An_AudienceLocationRepository : DataGivenWhenThen<AudienceLocationRepository>
    {
        protected override void Given( )
        {
            base.Given( );
            Sut = new AudienceLocationRepository( MockBubbleDataHandler );
        }
    }
}