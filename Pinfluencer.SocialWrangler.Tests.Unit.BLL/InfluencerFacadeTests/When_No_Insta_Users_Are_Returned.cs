using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.InstaUser;
using Pinfluencer.SocialWrangler.Core.Models.User;
using Pinfluencer.SocialWrangler.Tests.Unit.BLL.InfluencerFacadeTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.BLL.InfluencerFacadeTests
{
    public class When_No_Insta_Users_Are_Returned : When_Instagram_Error_Occurs
    {
        protected override void When( )
        {
            base.When( );
            MockSocialUserRepository
                .GetAll( )
                .Returns( new OperationResult<IEnumerable<InstaUser>>( Enumerable.Empty<InstaUser>(  ), OperationResultEnum.Success ) );
            Result = Sut.OnboardInfluencer( "123" );
        }

        [ Test ]
        public void Then_Get_Instagram_Users_Was_Called_Once( )
        {
            MockSocialUserRepository
                .Received( 1 )
                .GetAll( );
        }
        
        [ Test ]
        public void Then_Create_Influencer_Was_Not_Called( )
        {
            MockUserRepository
                .DidNotReceive( )
                .CreateInfluencer( Arg.Any<Influencer>( ) );
        }
    }
}