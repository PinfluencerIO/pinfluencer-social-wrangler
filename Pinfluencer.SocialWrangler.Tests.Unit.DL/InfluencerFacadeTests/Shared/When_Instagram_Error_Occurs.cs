using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.User;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.InfluencerFacadeTests.Shared
{
    public abstract class When_Instagram_Error_Occurs : When_Error_Occurs
    {
        protected override void When( )
        {
            MockUserRepository
                .Get( Arg.Any<string>( ) )
                .Returns( new ObjectResult<User>( new User { Name = "Aidan", Id = "123" },
                    OperationResultEnum.Success ) );
        }

        [ Test ]
        public void Then_Create_Influencer_Was_Not_Called( )
        {
            MockInfluencerRepository
                .DidNotReceive( )
                .Create( Arg.Any<Influencer>( ) );
        }
    }
}