using NSubstitute;
using Pinf.InstaService.Crosscutting.NUnit.PinfluencerExtensions;
using Pinf.InstaService.Crosscutting.Utils;
using Pinf.InstaService.DAL.Common.Handlers;
using Pinf.InstaService.DAL.Core.Interfaces.Clients;
using Pinf.InstaService.DAL.Core.Interfaces.Handlers;

namespace Pinf.InstaService.Tests.Unit.DAL.Common.BubbleHandlerTests
{
    public class Given_A_BubbleHandler : DataGivenWhenThen<object>
    {
        protected IBubbleClient MockBubbleClient;
        protected IBubbleDataHandler<object> BubbleSut;

        protected override void Given( )
        {
            base.Given( );
            MockBubbleClient = Substitute.For<IBubbleClient>( );

            BubbleSut = new BubbleDataHandler<object>( MockBubbleClient, MockLogger );
        }
    }
}