using Pinf.InstaService.Crosscutting.NUnit.PinfluencerExtensions;
using Pinf.InstaService.DAL.Instagram.Repositories;

namespace Pinf.InstaService.Tests.Unit.DAL.InstaImpressionsRepository
{
    public class Given_A_InstaImpressionsRepository : DataGivenWhenThen<InstagramImpressionsRepository>
    {
        protected override void Given( )
        {
            base.Given( );

            Sut = new InstagramImpressionsRepository(
                FacebookContext,
                MockLogger
            );
        }
    }
}