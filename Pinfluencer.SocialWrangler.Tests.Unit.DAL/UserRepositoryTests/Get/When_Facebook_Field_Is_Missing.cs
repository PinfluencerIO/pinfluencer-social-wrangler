﻿using System.Net;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Models;
using Pinfluencer.SocialWrangler.Core.Models.User;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble;
using Pinfluencer.SocialWrangler.Tests.Unit.DAL.UserRepositoryTests.Get.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.UserRepositoryTests.Get
{
    [ TestFixtureSource( nameof( data ) ) ]
    public class When_Facebook_Field_Is_Missing : When_Called
    {
        private OperationResult<User> _result;
        
        private readonly object _rawResponse;
        private readonly int _age;
        private readonly string _location;
        private readonly GenderEnum _gender;

        public When_Facebook_Field_Is_Missing( object rawResponse, int age, string location, GenderEnum gender )
        {
            _rawResponse = rawResponse;
            _age = age;
            _location = location;
            _gender = gender;
        }
        
        protected override void When( )
        {
            MockBubbleClient
                .Get<TypeResponse<Profile>>( Arg.Any<string>( ) )
                .Returns( ( HttpStatusCode.OK, new TypeResponse<Profile>
                    { Type = new Profile { Id = "1234", Name = "ExampleInfluencer" } } ) );
            MockFacebookClient
                .Get( Arg.Any<string>( ), Arg.Any<object>(  ) )
                .Returns( _rawResponse );
            _result = SUT.Get( "1234" );
        }

        [ Test ]
        public void Then_Valid_User_Is_Be_Returned( )
        {
            Assert.True( _result.Value.Id == "1234" &&
                         _result.Value.Name == "ExampleInfluencer" );
        }
        
        private static readonly object [ ] data =
        {
            new object[]
            { 
                new
                {
                    birthday = "11/26/1999",
                    gender = "male",
                    id = "706884236570098"
                },
                21,
                "Unknown",
                GenderEnum.Male
            },
            new object[]
            { 
                new
                {
                    birthday = "11/26/1999",
                    location = new
                    {
                        id = "109435875749334",
                        name = "Dorchester, Dorset",
                    },
                    id = "706884236570098"
                },
                21,
                "Dorchester, Dorset",
                GenderEnum.Unknown
            },
            new object[]
            { 
                new
                {
                    location = new
                    {
                        id = "109435875749334",
                        name = "Dorchester, Dorset",
                    },
                    gender = "male",
                    id = "706884236570098"
                },
                -1,
                "Dorchester, Dorset",
                GenderEnum.Male
            }
        };
    }
}