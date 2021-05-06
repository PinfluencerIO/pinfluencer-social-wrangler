using NSubstitute;
using Pinf.InstaService.Crosscutting.NUnit.PinfluencerExtensions;
using Pinf.InstaService.DAL.Core.Interfaces.Clients;
using Pinf.InstaService.DAL.Pinfluencer.Repositories;

namespace Pinf.InstaService.Tests.Unit.DAL.AudienceRepositoryTests
{
    public class Given_An_AudienceRepository : DataGivenWhenThen<AudienceRepository>
    {
        protected IBubbleClient MockBubbleClient;

        protected override void Given( )
        {
            base.Given( );
            MockBubbleClient = Substitute.For<IBubbleClient>( );
            Sut = new AudienceRepository( MockBubbleClient, MockLogger );
        }
    }
}