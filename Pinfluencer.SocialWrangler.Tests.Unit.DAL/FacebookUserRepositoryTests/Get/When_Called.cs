using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Models;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;
using Pinfluencer.SocialWrangler.DAL.Common.Dtos;
using Pinfluencer.SocialWrangler.DAL.Facebook.Dtos;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.FacebookUserRepositoryTests.Get
{
    [ TestFixtureSource( nameof( data ) ) ]
    public class When_Called : Given_A_FacebookUserRepository
    {
        private readonly OperationResult<ISocialInfoUser> _operationResult;

        private OperationResult<ISocialInfoUser> _result;

        public When_Called( Func<ISocialInfoUser,ISocialInfoUser> func, OperationResultEnum operationResultEnum )
        {
            base.Given( );
            _operationResult = new OperationResult<ISocialInfoUser>( func( SocialInfoUser ), operationResultEnum );
        }

        private static readonly object [ ] data =
        {
            new object[ ]
            {
                ( Func<ISocialInfoUser,ISocialInfoUser> )( x =>
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
            new object[ ]
            {
                ( Func<ISocialInfoUser,ISocialInfoUser> )( x => x),
                OperationResultEnum.Failed
            }
        };

        protected override void When( )
        {
            MockFacebookDataHandler
                .Read( Arg.Any<string>( ),
                    Arg.Any<Func<FacebookUser, ISocialInfoUser>>( ),
                    Arg.Any<ISocialInfoUser>( ),
                    Arg.Any<object>( ) )
                .Returns( _operationResult );
            _result = SUT.Get( );
        }
        
        [ Test ] public void Then_Get_Users_Is_Called_Once( ) =>
            MockFacebookDataHandler
                .Received( 1 )
                .Read( Arg.Any<string>( ),
                    Arg.Any<Func<FacebookUser, ISocialInfoUser>>( ),
                    Arg.Any<ISocialInfoUser>( ) );

        [ Test ] public void Then_Valid_Call_Was_Made( ) =>
            MockFacebookDataHandler
                .Received( )
                .Read<ISocialInfoUser,FacebookUser>( "me",
                    SUT.MapOut,
                    Arg.Is<ISocialInfoUser>( x => x.Age == default &&
                                                  x.Gender == default &&
                                                  x.Id == default &&
                                                  x.Location == default &&
                                                  x.Name == default ) );

        [ Test ] public void Then_Valid_Response_Was_Returned( ) =>
            Assert.AreSame( _operationResult, _result );
    }
}