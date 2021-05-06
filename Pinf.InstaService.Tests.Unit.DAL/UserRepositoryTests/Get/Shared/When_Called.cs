﻿using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.DAL.Common.Dtos;

namespace Pinf.InstaService.Tests.Unit.DAL.UserRepositoryTests.Get.Shared
{
    public abstract class When_Called : Given_A_UserRepository
    {
        [ Test ]
        public void Then_Facebook_User_Will_Be_Fetched_Once( )
        {
            MockFacebookClient
                .Received( 1 )
                .Get( Arg.Any<string>( ), Arg.Any<object>( )  );
        }

        [ Test ]
        public void Then_Correct_Facebook_User_Endpoint_Is_Reached( )
        {
            MockFacebookClient
                .Received( )
                .Get( Arg.Is<string>( uri => uri == "me" ), Arg.Any<object>( )  );
        }

        [ Test ]
        public void Then_Correct_Facebook_User_Endpoint_Is_Passed_The_Correct_Fields( )
        {
            MockFacebookClient
                .Received( )
                .Get( Arg.Is<string>( uri => uri == "me" ), Arg.Is<RequestFields>( x => x.fields == "birthday,location,gender" )  );
        }
    }
}