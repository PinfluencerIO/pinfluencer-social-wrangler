using NSubstitute;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Clients;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Handlers;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;
using Pinfluencer.SocialWrangler.DAL.Common.Handlers;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.Common.BubbleHandlerTests
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