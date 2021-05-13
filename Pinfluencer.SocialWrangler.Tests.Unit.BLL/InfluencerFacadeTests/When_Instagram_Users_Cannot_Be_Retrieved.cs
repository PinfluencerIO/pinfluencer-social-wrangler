using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.InstaUser;
using Pinfluencer.SocialWrangler.Tests.Unit.BLL.InfluencerFacadeTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.BLL.InfluencerFacadeTests
{
    public class When_Instagram_Users_Cannot_Be_Retrieved : When_Instagram_Error_Occurs
    {
        protected override void When( )
        {
            base.When( );
            MockSocialUserRepository
                .GetAll( )
                .Returns( new OperationResult<IEnumerable<InstaUser>>( Enumerable.Empty<InstaUser>(  ), OperationResultEnum.Failed ) );
            Result = Sut.OnboardInfluencer( "123" );
        }
    }
}