using Pinf.InstaService.BLL.Facades;
using Pinf.InstaService.Core.Interfaces.Repositories;
using NSubstitute;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Crosscutting.NUnit.PinfluencerExtensions;

namespace Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InfluencerFacadeTests
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