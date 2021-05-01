using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Models;
using Pinf.InstaService.Core.Models.InstaUser;
using Pinf.InstaService.Core.Models.User;
using Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InfluencerFacadeTests.Shared;

namespace Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InfluencerFacadeTests
{
    public class When_Instagram_Users_Cannot_Be_Retrieved : When_Instagram_Error_Occurs
    {
        protected override void When( )
        {
            base.When( );
            MockInstaUserRepository
                .GetAll( )
                .Returns( new OperationResult<IEnumerable<InstaUser>>( Enumerable.Empty<InstaUser>(  ), OperationResultEnum.Failed ) );
            Result = Sut.OnboardInfluencer( "123" );
        }
    }
}