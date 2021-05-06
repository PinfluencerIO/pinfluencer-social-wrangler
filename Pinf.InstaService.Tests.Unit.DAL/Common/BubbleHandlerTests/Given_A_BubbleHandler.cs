using NSubstitute;
using Pinf.InstaService.Crosscutting.NUnit.PinfluencerExtensions;
using Pinf.InstaService.DAL.Common.Handlers;
using Pinf.InstaService.DAL.Core.Interfaces.Clients;

namespace Pinf.InstaService.Tests.Unit.DAL.Common.BubbleHandlerTests
{
    public class Given_A_BubbleHandler : DataGivenWhenThen<BubbleDataHandler>
    {
        protected IBubbleClient MockBubbleClient;

        protected override void Given( )
        {
            base.Given( );
            MockBubbleClient = Substitute.For<IBubbleClient>( );

            Sut = new BubbleDataHandler( MockBubbleClient, MockLogger );
        }
    }
}