using NSubstitute;
using Pinf.InstaService.Bootstrapping.Services.Repositories;
using Pinf.InstaService.Crosscutting.NUnit.Extensions;

namespace Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InstaUserService
{
    public abstract class
        Given_A_InstaUserService : GivenWhenThen<InstaService.BLL.InstagramFetcher.Services.InstaUserService>
    {
        protected IInstaUserRepository MockInstaUserRepository;

        protected override void Given()
        {
            MockInstaUserRepository = Substitute.For<IInstaUserRepository>();

            Sut = new InstaService.BLL.InstagramFetcher.Services.InstaUserService(MockInstaUserRepository);
        }
    }
}