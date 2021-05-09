using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Models;
using Pinf.InstaService.Core.Models.InstaUser;
using Pinf.InstaService.Core.Models.User;
using Pinf.InstaService.Tests.Unit.BLL.InfluencerFacadeTests.Shared;

namespace Pinf.InstaService.Tests.Unit.BLL.InfluencerFacadeTests
{
    public class When_Influencer_Cannot_Be_Created : When_Error_Occurs
    { 
        protected override void When( )
        {
            MockUserRepository
                .Get( Arg.Any<string>( ) )
                .Returns( new OperationResult<IUser>( GetUser( DefaultUser ), OperationResultEnum.Success ) );
            MockSocialUserRepository
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
                .Returns( OperationResultEnum.Failed );
            Result = Sut.OnboardInfluencer( "123" );
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
        public void Then_Get_Instagram_Users_Was_Called_Once( )
        {
            MockSocialUserRepository
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