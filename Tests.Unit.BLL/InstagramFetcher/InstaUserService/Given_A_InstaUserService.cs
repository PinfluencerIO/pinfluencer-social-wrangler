using BLL.Models.InstaUser;
using Bootstrapping.Services.Repositories;
using Crosscutting.Testing.Extensions;
using NSubstitute;

namespace Tests.Unit.BLL.InstagramFetcher.InstaUserService
{
    public abstract class Given_A_InstaUserService : GivenWhenThen<global::BLL.InstagramFetcher.Services.InstaUserService>
    {
        protected IInstaUserRepository MockInstaUserRepository;

        protected override void Given()
        {
            MockInstaUserRepository = Substitute.For<IInstaUserRepository>();

            Sut = new global::BLL.InstagramFetcher.Services.InstaUserService(MockInstaUserRepository);
        }
    }
}