using Facebook;
using NSubstitute;
using Pinf.InstaService.Crosscutting.NUnit.Extensions;
using Pinf.InstaService.Crosscutting.NUnit.PinfluencerExtensions;
using Pinf.InstaService.DAL.Common;
using Pinf.InstaService.DAL.Instagram;
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