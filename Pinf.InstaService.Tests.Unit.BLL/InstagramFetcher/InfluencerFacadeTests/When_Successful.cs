using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Models;
using Pinf.InstaService.Core.Models.InstaUser;
using Pinf.InstaService.Core.Models.User;
using Pinf.InstaService.Crosscutting.NUnit.PinfluencerExtensions;

namespace Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InfluencerFacadeTests
{
    public class When_Successful : Given_A_InfluencerFacade
    {
        private OperationResultEnum _result;

        protected override void When( )
        {
            MockUserRepository
                .Get( Arg.Any<string>( ) )
                .Returns( new OperationResult<IUser>( GetUser( DefaultUser ), OperationResultEnum.Success ) );
            MockInstaUserRepository
                .GetAll( )
                .Returns( new OperationResult<IEnumerable<InstaUser>>( new [ ]
                {
                    new InstaUser
                    {
                        Bio = "This is an example",
                        Followers = 212,
                        Handle = "examplehandle",
                        Id = "654321",
                        Name = "Aidan Gannon"
                    }
                }, OperationResultEnum.Success ) );
            MockUserRepository
                .CreateInfluencer( Arg.Any<Influencer>( ) )
                .Returns( OperationResultEnum.Success );
            _result = Sut.OnboardInfluencer( "123" );
        }

        [ Test ]
        public void Then_Valid_Influencer_Was_Created( )
        {
            MockUserRepository
                .Received( )
                .CreateInfluencer( Arg.Is<Influencer>( x =>
                    x.Age == 21 &&
                    x.Bio == "This is an example" &&
                    x.Gender == GenderEnum.Male &&
                    x.Location == "London" &&
                    x.User.Id == "123" &&
                    x.InstagramHandle == "examplehandle" ) );
        }

        [ Test ]
        public void Then_Success_Was_Returned( )
        {
            Assert.AreEqual( OperationResultEnum.Success, _result );
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
        public void Then_Create_Influencer_Was_Called_Once( )
        {
            MockUserRepository
                .Received( 1 )
                .CreateInfluencer( Arg.Any<Influencer>( ) );
        }
    }
}