using Pinf.InstaService.BLL.Facades;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.Crosscutting.NUnit.Extensions;
using NSubstitute;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Crosscutting.NUnit.PinfluencerExtensions;

namespace Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InfluencerFacadeTests
{
    public class Given_A_InfluencerFacade : PinfluencerGivenWhenThen<InfluencerFacade>
    {
        protected IUserRepository MockUserRepository;
        protected IInstaUserRepository MockInstaUserRepository;
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
            MockInstaUserRepository = Substitute.For<IInstaUserRepository>( );

            Sut = new InfluencerFacade( MockUserRepository, MockInstaUserRepository );
        }
    }
}