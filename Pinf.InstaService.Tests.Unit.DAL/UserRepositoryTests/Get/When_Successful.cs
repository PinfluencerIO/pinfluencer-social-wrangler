using System;
using System.Net;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Dtos;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Models.User;
using Pinf.InstaService.DAL.UserManagement.Dtos;
using Pinf.InstaService.DAL.UserManagement.Dtos.Bubble;

namespace Pinf.InstaService.Tests.Unit.DAL.UserRepositoryTests.Get
{
    public class When_Successful : Given_A_UserRepository
    {
        private OperationResult<User> _result;

        protected override void When( )
        {
            MockBubbleClient
                .Get<TypeResponse<Profile>>( Arg.Any<string>( ) )
                .Returns( ( HttpStatusCode.OK, new TypeResponse<Profile>
                    { Type = new Profile { Id = "1234", Name = "ExampleInfluencer" } } ) );
            _result = Sut.Get( "1234" );
        }

        [ Test ]
        public void Then_Profile_Will_Be_Verified_Once( )
        {
            MockBubbleClient
                .Received( 1 )
                .Get<TypeResponse<Profile>>( Arg.Any<string>( ) );
        }

        [ Test ]
        public void Then_Correct_Profile_Endpoint_Is_Reached( )
        {
            MockBubbleClient
                .Received( 1 )
                .Get<TypeResponse<Profile>>( Arg.Is<string>( uri => uri == "profile/1234" ) );
        }

        [ Test ]
        public void Then_Valid_User_Is_Be_Returned( )
        {
            Assert.True( _result.Value.Id == "1234" && _result.Value.Name == "ExampleInfluencer" );
        }
        
        [ Test ]
        public void Then_Success_Is_Returned( )
        {
            Assert.AreEqual( OperationResultEnum.Success, _result.Status );
        }
    }
}