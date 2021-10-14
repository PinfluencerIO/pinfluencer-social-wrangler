using System;
using Aidan.Common.Core;
using Aidan.Common.Core.Enum;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.DAL.Common.Dtos;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.FacebookUserRepositoryTests.Get
{
    [ TestFixtureSource( nameof( data ) ) ]
    public class When_Called : Given_A_FacebookUserRepository
    {
        private readonly ObjectResult<SocialInfoUser> _objectResult;

        private ObjectResult<SocialInfoUser> _result;

        public When_Called( Func<SocialInfoUser, SocialInfoUser> func, OperationResultEnum operationResultEnum )
        {
            base.Given( );
            _objectResult =
                new ObjectResult<SocialInfoUser>( func( new SocialInfoUser( ) ), operationResultEnum );
        }

        private static readonly object [ ] data =
        {
            new object [ ]
            {
                ( Func<SocialInfoUser, SocialInfoUser> ) ( x =>
                {
                    x.Age = 21;
                    x.Gender = GenderEnum.Male;
                    x.Id = "123";
                    x.Location = new LocationProperty
                    {
                        Country = "United Kingdom",
                        CountryCode = CountryEnum.GB
                    };
                    x.Name = "Aidan Gannon";
                    return x;
                } ),
                OperationResultEnum.Success
            },
            new object [ ]
            {
                ( Func<SocialInfoUser, SocialInfoUser> ) ( x => x ),
                OperationResultEnum.Failed
            }
        };

        protected override void When( )
        {
            MockFacebookDataHandler
                .Read( Arg.Any<string>( ),
                    Arg.Any<Func<FacebookUser, SocialInfoUser>>( ),
                    Arg.Any<SocialInfoUser>( ),
                    Arg.Any<object>( ) )
                .Returns( _objectResult );
            _result = SUT.Get( );
        }

        [ Test ]
        public void Then_Get_Users_Is_Called_Once( )
        {
            MockFacebookDataHandler
                .Received( 1 )
                .Read( Arg.Any<string>( ),
                    Arg.Any<Func<FacebookUser, SocialInfoUser>>( ),
                    Arg.Any<SocialInfoUser>( ),
                    Arg.Any<RequestFields>( ) );
        }

        [ Test ]
        public void Then_Valid_Call_Was_Made( )
        {
            MockFacebookDataHandler
                .Received( )
                .Read<SocialInfoUser, FacebookUser>( "me",
                    SUT.MapOut,
                    Arg.Is<SocialInfoUser>( x => x.Age == default &&
                                                 x.Gender == default &&
                                                 x.Id == default &&
                                                 x.Location == default &&
                                                 x.Name == default ),
                    Arg.Is<RequestFields>( x =>
                        x.fields == "birthday,location{location{city,country,country_code}},gender,name" ) );
        }

        [ Test ]
        public void Then_Valid_Response_Was_Returned( ) { Assert.AreSame( _objectResult, _result ); }
    }
}