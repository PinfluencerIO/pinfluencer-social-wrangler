using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Models;
using Pinf.InstaService.Core.Models.InstaUser;
using Pinf.InstaService.Core.Models.User;

namespace Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InfluencerFacadeTests
{
    public class When_No_Insta_Users_Are_Returned : Given_A_InfluencerFacade
    {
        private OperationResultEnum _result;

        protected override void When( )
        {
            MockUserRepository
                .Get( Arg.Any<string>( ) )
                .Returns( new OperationResult<IUser>( GetUser( DefaultUser ), OperationResultEnum.Success ) );
            MockInstaUserRepository
                .GetAll( )
                .Returns( new OperationResult<IEnumerable<InstaUser>>( Enumerable.Empty<InstaUser>(  ), OperationResultEnum.Success ) );
            _result = Sut.OnboardInfluencer( "123" );
        }

        [ Test ]
        public void Then_Failiure_Was_Returned( )
        {
            Assert.AreEqual( OperationResultEnum.Failed, _result );
        }

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

        [ Test ]
        public void Then_Get_Instagram_Users_Was_Called_Once( )
        {
            MockInstaUserRepository
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