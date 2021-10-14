using Aidan.Common.Core;
using Aidan.Common.Core.Enum;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Models.User;
using Pinfluencer.SocialWrangler.Tests.Unit.DL.InfluencerFacadeTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.InfluencerFacadeTests
{
    public class When_Successful : When_Called
    {
        private OperationResultEnum _result;

        protected override void When( )
        {
            MockUserRepository
                .Get( Arg.Any<string>( ) )
                .Returns( new ObjectResult<User>( DefaultUser, OperationResultEnum.Success ) );
            MockGetInfluencerFromSocialCommand
                .Run( )
                .Returns( new ObjectResult<Influencer>( DefaultInfluencerFromSocial, OperationResultEnum.Success ) );
            MockInfluencerRepository
                .Create( Arg.Any<Influencer>( ) )
                .Returns( OperationResultEnum.Success );
            _result = SUT.Onboard( "123" );
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
                    x.Location.Country == "United Kingdom" &&
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