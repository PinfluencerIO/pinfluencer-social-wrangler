using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.Core.Models.User;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.InfluencerFacadeTests.Shared
{
    public abstract class When_Called : Given_A_InfluencerFacade
    {
        protected Influencer DefaultInfluencerFromSocial => new Influencer
        {
            Age = 21,
            Gender = GenderEnum.Male,
            Location = new LocationProperty
            {
                City = "London",
                Country = "United Kingdom",
                CountryCode = CountryEnum.GB
            },
            Bio = "This is an example",
            SocialUsername = "examplehandle"
        };

        protected User DefaultUser => new User { Name = "Aidan", Id = "123" };

        [ Test ]
        public void Then_Correct_User_Was_Called( )
        {
            MockUserRepository
                .Received( )
                .Get( Arg.Is( "123" ) );
        }

        [ Test ]
        public void Then_Get_User_Was_Called_Once( )
        {
            MockUserRepository
                .Received( 1 )
                .Get( Arg.Any<string>( ) );
        }
    }
}