using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.Core.Models.User;
using Pinfluencer.SocialWrangler.Tests.Unit.DL.GetInfluencerFromSocialCommandTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.GetInfluencerFromSocialCommandTests
{
    public class When_Successful : When_Called
    {
        private ObjectResult<Influencer> _result;

        protected override void When( )
        {
            MockInsightsSocialUserRepository
                .GetAll( )
                .Returns( new ObjectResult<IEnumerable<SocialInsightsUser>>( new [ ] { DefaultSocialInsightsUser },
                    OperationResultEnum.Success ) );
            MockSocialInfoUserRepository
                .Get( )
                .Returns( new ObjectResult<SocialInfoUser>( DefaultSocialInfoUser, OperationResultEnum.Success ) );
            _result = SUT.Run( );
        }

        [ Test ]
        public void Then_Valid_Influencer_Was_Returned( )
        {
            var influencer = _result.Value;
            Assert.AreEqual( 21, influencer.Age );
            Assert.AreEqual( "This is an example", influencer.Bio );
            Assert.AreEqual( GenderEnum.Male, influencer.Gender );
            Assert.AreEqual( "United Kingdom", influencer.Location.Country );
            Assert.AreEqual( "London", influencer.Location.City );
            Assert.AreEqual( "examplehandle", influencer.SocialUsername );
        }

        [ Test ]
        public void Then_Success_Was_Returned( ) { Assert.AreEqual( OperationResultEnum.Success, _result.Status ); }
    }
}