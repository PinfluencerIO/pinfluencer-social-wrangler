using System;
using System.Net;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Models;
using Pinf.InstaService.Core.Models.User;
using Pinf.InstaService.DAL.Common.Dtos;
using Pinf.InstaService.DAL.UserManagement.Dtos.Bubble;
using Pinf.InstaService.Tests.Unit.DAL.UserRepositoryTests.Get.Shared;
using Influencer = Pinf.InstaService.DAL.UserManagement.Dtos.Bubble.Influencer;

namespace Pinf.InstaService.Tests.Unit.DAL.UserRepositoryTests.Get
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
                .Get<FacebookUser>( Arg.Any<string>( ), Arg.Any<object>(  ) )
                .Returns( new FacebookUser
                {
                    Location = new FacebookPage
                    {
                        Id = "1235",
                        Name = "London"
                    },
                    Birthday = "11/26/1999",
                    Gender = "female"
                } );
            _result = Sut.Get( "1234" );
        }

        [ Test ]
        public void Then_Valid_User_Is_Be_Returned( )
        {
            Assert.True( _result.Value.Id == "1234" &&
             _result.Value.Name == "ExampleInfluencer" &&
             _result.Value.Age == 21 &&
             _result.Value.Location == "London" &&
             _result.Value.Gender == GenderEnum.Female );
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