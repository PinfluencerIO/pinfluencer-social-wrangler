using System;
using System.Collections.Generic;
using System.Linq;
using Aidan.Common.Core;
using Aidan.Common.Core.Enum;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.DAL.Common.Dtos;
using Pinfluencer.SocialWrangler.DAL.Core.Dtos.Dtos;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramUserRepositoryTests.GetUsers
{
    [ TestFixtureSource( nameof( data ) ) ]
    public class When_Called : Given_A_InstagramUserRepository
    {
        private readonly ObjectResult<IEnumerable<SocialInsightsUser>> _objectResult;

        private static IEnumerable<ObjectResult<IEnumerable<SocialInsightsUser>>> data = new [ ]
        {
            new ObjectResult<IEnumerable<SocialInsightsUser>>( new [ ]
            {
                new SocialInsightsUser
                {
                    Bio = "example bio",
                    Followers = 123,
                    Id = "123",
                    Name = "Aidan Gannon",
                    Username = "aidangannon"
                }
            }, OperationResultEnum.Success ),
            new ObjectResult<IEnumerable<SocialInsightsUser>>( Enumerable.Empty<SocialInsightsUser>( ),
                OperationResultEnum.Failed )
        };

        private ObjectResult<IEnumerable<SocialInsightsUser>> _result;

        public When_Called( ObjectResult<IEnumerable<SocialInsightsUser>> objectResult )
        {
            _objectResult = objectResult;
        }

        protected override void When( )
        {
            MockFacebookDataHandler
                .Read( Arg.Any<string>( ),
                    Arg.Any<Func<DataArray<FacebookPage>, IEnumerable<SocialInsightsUser>>>( ),
                    Arg.Any<IEnumerable<SocialInsightsUser>>( ),
                    Arg.Any<object>( ) )
                .Returns( _objectResult );
            _result = SUT.GetAll( );
        }

        [ Test ]
        public void Then_Get_Users_Is_Called_Once( )
        {
            MockFacebookDataHandler
                .Received( 1 )
                .Read( Arg.Any<string>( ),
                    Arg.Any<Func<DataArray<FacebookPage>, IEnumerable<SocialInsightsUser>>>( ),
                    Arg.Any<IEnumerable<SocialInsightsUser>>( ),
                    Arg.Any<object>( ) );
        }

        [ Test ]
        public void Then_Valid_Call_Was_Made( )
        {
            MockFacebookDataHandler
                .Received( )
                .Read<IEnumerable<SocialInsightsUser>, DataArray<FacebookPage>>( "me/accounts",
                    SUT.MapMany,
                    Arg.Is<IEnumerable<SocialInsightsUser>>( x => !x.Any( ) ),
                    Arg.Is<RequestFields>( x =>
                        x.fields == "instagram_business_account{id,username,name,biography,followers_count}" ) );
        }

        [ Test ]
        public void Then_Valid_Response_Was_Returned( ) { Assert.AreSame( _objectResult, _result ); }
    }
}