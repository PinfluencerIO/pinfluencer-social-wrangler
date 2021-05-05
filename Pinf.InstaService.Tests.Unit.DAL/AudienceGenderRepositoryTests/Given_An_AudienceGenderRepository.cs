using NSubstitute;
using Pinf.InstaService.Core.Interfaces.Clients;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.Crosscutting.NUnit.PinfluencerExtensions;
using Pinf.InstaService.DAL.Pinfluencer.Repositories;

namespace Pinf.InstaService.Tests.Unit.DAL.AudienceGenderRepositoryTests
{
    public class Given_An_AudienceGenderRepository : DataGivenWhenThen<AudienceGenderRepository>
    {
        protected IBubbleClient MockBubbleClient;

        protected override void Given( )
        {
            base.Given( );
            MockBubbleClient = Substitute.For<IBubbleClient>( );
            Sut = new AudienceGenderRepository( MockBubbleClient, MockLogger );
        }
    }
}