using System.Net;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Models;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble;
using Pinfluencer.SocialWrangler.Tests.Unit.DAL.UserRepositoryTests.Get.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.UserRepositoryTests.Get
{
    public class When_Successful : When_Facebook_Error_Does_Not_Occur
    {
        private OperationResult<IUser> _result;

        protected override void When( )
        {
            MockBubbleClient
                .Get<TypeResponse<Profile>>( Arg.Any<string>( ) )
                .Returns( ( HttpStatusCode.OK, new TypeResponse<Profile>
                    { Type = new Profile { Id = "1234", Name = "ExampleInfluencer" } } ) );
            MockFacebookClient
                .Get( Arg.Any<string>( ), Arg.Any<object>(  ) )
                .Returns( new
                {
                    birthday = "11/26/1999",
                    location = new
                    {
                        id = "109435875749334",
                        name = "Dorchester, Dorset",
                    },
                    gender = "male",
                    id = "706884236570098"
                } );
            _result = Sut.Get( "1234" );
        }

        [ Test ]
        public void Then_Valid_User_Is_Be_Returned( )
        {
            Assert.True( _result.Value.Id == "1234" &&
             _result.Value.Name == "ExampleInfluencer" &&
             _result.Value.Age == 21 &&
             _result.Value.Location == "Dorchester, Dorset" &&
             _result.Value.Gender == GenderEnum.Male );
        }

        [ Test ]
        public void Then_Success_Is_Returned( ) { Assert.AreEqual( OperationResultEnum.Success, _result.Status ); }
        
        [ Test ]
        public void Then_Success_Event_Is_Logged( )
        {
            MockLogger
                .Received( )
                .LogInfo( Arg.Any<string>( ) );
        }
    }
}