using NSubstitute;
using Pinf.InstaService.Crosscutting.NUnit.PinfluencerExtensions;
using Pinf.InstaService.DAL.Core.Interfaces.Clients;
using Pinf.InstaService.DAL.Pinfluencer.Repositories;

namespace Pinf.InstaService.Tests.Unit.DAL.AudienceGenderRepositoryTests
{
    public class Given_An_AudienceGenderRepository : DataGivenWhenThen<AudienceGenderRepository>
    {
        protected override void Given( )
        {
            base.Given( );
            Sut = new AudienceGenderRepository( MockBubbleDataHandler );
        }
    }
}