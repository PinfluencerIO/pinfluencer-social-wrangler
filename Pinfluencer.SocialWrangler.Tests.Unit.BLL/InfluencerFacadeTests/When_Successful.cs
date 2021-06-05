﻿using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.Core.Models.User;
using Pinfluencer.SocialWrangler.Tests.Unit.BLL.InfluencerFacadeTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.BLL.InfluencerFacadeTests
{
    public class When_Successful : When_Called
    {
        private OperationResultEnum _result;

        protected override void When( )
        {
            MockUserRepository
                .Get( Arg.Any<string>( ) )
                .Returns( new OperationResult<User>( DefaultUser, OperationResultEnum.Success ) );
            InsightsSocialUserRepository
                .GetAll( )
                .Returns( new OperationResult<IEnumerable<SocialInsightsUser>>( new [ ] { DefaultSocialInsightsUser },
                    OperationResultEnum.Success ) );
            SocialInfoUserRepository
                .Get( )
                .Returns( new OperationResult<SocialInfoUser>( DefaultSocialInfoUser, OperationResultEnum.Success ) );
            MockInfluencerRepository
                .Create( Arg.Any<Influencer>( ) )
                .Returns( OperationResultEnum.Success );
            _result = SUT.OnboardInfluencer( "123" );
        }

        [ Test ]
        public void Then_Valid_Influencer_Was_Created( )
        {
            MockInfluencerRepository
                .Received( )
                .Create( Arg.Is<Influencer>( x =>
                    x.Age == 21 &&
                    x.Bio == "This is an example" &&
                    x.Gender == GenderEnum.Male &&
                    x.Location == "United Kingdom" &&
                    x.User.Id == "123" &&
                    x.SocialUsername == "examplehandle" ) );
        }

        [ Test ]
        public void Then_Success_Was_Returned( ) { Assert.AreEqual( OperationResultEnum.Success, _result ); }

        [ Test ]
        public void Then_Create_Influencer_Was_Called_Once( )
        {
            MockInfluencerRepository
                .Received( 1 )
                .Create( Arg.Any<Influencer>( ) );
        }
    }
}