using NSubstitute;
using Pinf.InstaService.Crosscutting.NUnit.PinfluencerExtensions;
using Pinf.InstaService.DAL.Core.Interfaces.Clients;
using Pinf.InstaService.DAL.Pinfluencer.Repositories;

namespace Pinf.InstaService.Tests.Unit.DAL.AudienceRepositoryTests
{
    public class Given_An_AudienceRepository : DataGivenWhenThen<AudienceRepository>
    {
        protected override void Given( )
        {
            base.Given( );
            Sut = new AudienceRepository( MockBubbleDataHandler );
        }
    }
}