using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Facebook.Repositories;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstaImpressionsRepository
{
    public class Given_A_InstaImpressionsRepository : DataGivenWhenThen<InstagramImpressionsRepository>
    {
        protected override void Given( )
        {
            base.Given( );

            SUT = new InstagramImpressionsRepository(
                FacebookDecorator,
                MockLogger
            );
        }
    }
}