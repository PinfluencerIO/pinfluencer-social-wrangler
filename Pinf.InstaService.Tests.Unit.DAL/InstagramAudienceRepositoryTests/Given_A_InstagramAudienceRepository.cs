using Facebook;
using NSubstitute;
using Pinf.InstaService.Crosscutting.NUnit.PinfluencerExtensions;
using Pinf.InstaService.DAL.Common;
using Pinf.InstaService.DAL.Instagram.Repositories;

namespace Pinf.InstaService.Tests.Unit.DAL.InstagramAudienceRepositoryTests
{
    public class Given_A_InstagramAudienceRepository : DataGivenWhenThen<InstagramAudienceRepository>
    {
        protected override void Given( )
        {
            base.Given( );
            Sut = new InstagramAudienceRepository( new FacebookContext{ FacebookClient = MockFacebookClient } );
        }
    }
}