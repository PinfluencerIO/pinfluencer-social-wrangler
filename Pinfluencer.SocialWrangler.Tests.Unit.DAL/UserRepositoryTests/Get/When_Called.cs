using System;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.User;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.UserRepositoryTests.Get
{
    [ TestFixtureSource( nameof( data ) ) ]
    public class When_Called : Given_A_UserRepository
    {
        private readonly ObjectResult<User> _objectResult;

        private ObjectResult<User> _result;

        public When_Called( User user, OperationResultEnum operationResultEnum )
        {
            _objectResult = new ObjectResult<User>( user, operationResultEnum );
        }

        private static readonly object [ ] data =
        {
            new object [ ]
            {
                new User
                {
                    Id = "12345",
                    Name = "Aidan Gannon"
                },
                OperationResultEnum.Failed
            },
            new object [ ]
            {
                new User( ),
                OperationResultEnum.Success
            }
        };

        protected override void When( )
        {
            MockBubbleDataHandler
                .Read( Arg.Any<string>( ),
                    Arg.Any<Func<TypeResponse<Profile>, User>>( ),
                    Arg.Any<User>( ) )
                .Returns( _objectResult );
            _result = SUT.Get( "54321" );
        }

        [ Test ]
        public void Then_Data_Was_Read_Once( )
        {
            MockBubbleDataHandler
                .Received( 1 )
                .Read( Arg.Any<string>( ),
                    Arg.Any<Func<TypeResponse<Profile>, User>>( ),
                    Arg.Any<User>( ) );
        }

        [ Test ]
        public void Then_Valid_Call_Was_Made( )
        {
            MockBubbleDataHandler
                .Received( )
                .Read<User, TypeResponse<Profile>>( "profile/54321",
                    SUT.MapOut,
                    Arg.Is<User>( x =>
                        x.Id == default &&
                        x.Name == default ) );
        }

        [ Test ]
        public void Then_Response_Was_Valid( ) { Assert.AreSame( _objectResult, _result ); }
    }
}