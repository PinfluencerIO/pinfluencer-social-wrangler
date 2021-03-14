using BLL.InstagramFetcher.Validation;
using Bootstrapping.Services.Repositories;
using Crosscutting.Testing.Extensions;
using NSubstitute;

namespace Tests.Unit.BLL.InstagramFetcher.InstaInsightsCollectionFactory
{
    public abstract class Given_A_InstaInsightsCollectionFactory : GivenWhenThen<global::BLL.InstagramFetcher.Service.InstaInsightsCollectionFactory>
    {
        protected IInstaAudienceInsightsRepository MockAudienceInsightsRepository;
        
        protected override void Given()
        {
            MockAudienceInsightsRepository = Substitute.For<IInstaAudienceInsightsRepository>();

            Sut = new global::BLL.InstagramFetcher.Service.InstaInsightsCollectionFactory(
                MockAudienceInsightsRepository,
                new ValidateInstaAudienceAgeRange(),
                new ValidateCountry()
            );
        }
    }
}