using Pinfluencer.SocialWrangler.BLL.Facades;
using Pinfluencer.SocialWrangler.Core.Interfaces.Repositories;
using NSubstitute;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;

namespace Pinfluencer.SocialWrangler.Tests.Unit.BLL.InfluencerFacadeTests
{
    public class Given_A_InfluencerFacade : PinfluencerGivenWhenThen<InfluencerFacade>
    {
        protected IUserRepository MockUserRepository;
        protected ISocialUserRepository MockSocialUserRepository;
        protected readonly FakeUserProps DefaultUser = new FakeUserProps
        {
            Age = 21,
            Gender = GenderEnum.Male,
            Id = "123",
            Location = "London",
            Name = "Aidan"
        };

        protected override void Given( )
        {
            MockUserRepository = Substitute.For<IUserRepository>( );
            MockSocialUserRepository = Substitute.For<ISocialUserRepository>( );

            Sut = new InfluencerFacade( MockUserRepository, MockSocialUserRepository );
        }
    }
}