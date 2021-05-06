using Pinf.InstaService.Crosscutting.NUnit.PinfluencerExtensions;
using Pinf.InstaService.DAL.Instagram.Repositories;

namespace Pinf.InstaService.Tests.Unit.DAL.InstaUserRepository
{
    public abstract class Given_A_InstaUserRepository : DataGivenWhenThen<InstagramUserRepository>
    {
        protected override void Given( )
        {
            base.Given( );

            Sut = new InstagramUserRepository(
                FacebookContext,
                MockLogger
            );
        }
    }
}