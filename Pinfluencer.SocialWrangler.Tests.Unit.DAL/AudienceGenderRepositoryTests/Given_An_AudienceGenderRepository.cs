using NSubstitute;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Clients;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Repositories;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.AudienceGenderRepositoryTests
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