using NSubstitute;
using NUnit.Framework;

namespace Pinf.InstaService.Tests.Unit.BLL.InfluencerFacadeTests.Shared
{
    public abstract class When_Called : Given_A_InfluencerFacade
    {
        [ Test ]
        public void Then_Correct_User_Was_Called( )
        {
            MockUserRepository
                .Received()
                .Get( Arg.Is( "123" ) );
        }

        [ Test ]
        public void Then_Get_User_Was_Called_Once( )
        {
            MockUserRepository
                .Received( 1 )
                .Get( Arg.Any<string>( ) );
        }
    }
}