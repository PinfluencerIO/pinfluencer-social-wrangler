using NSubstitute;
using Pinfluencer.SocialWrangler.BLL.Facades;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.FrontFacing.Pinfluencer;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.FrontFacing.Social;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;

namespace Pinfluencer.SocialWrangler.Tests.Unit.BLL.InfluencerFacadeTests
{
    public class Given_A_InfluencerFacade : PinfluencerGivenWhenThen<InfluencerFacade>
    {
        protected readonly SocialInfoUser DefaultSocialInfoUser = new SocialInfoUser
        {
            Age = 21,
            Gender = GenderEnum.Male,
            Id = "123",
            Location = new LocationProperty
            {
                Country = "United Kingdom",
                CountryCode = CountryEnum.GB
            },
            Name = "Aidan"
        };

        protected IInsightsSocialUserRepository InsightsSocialUserRepository;

        protected IInfluencerRepository MockInfluencerRepository;
        protected IUserRepository MockUserRepository;
        protected ISocialInfoUserRepository SocialInfoUserRepository;

        protected override void Given( )
        {
            MockUserRepository = Substitute.For<IUserRepository>( );
            InsightsSocialUserRepository = Substitute.For<IInsightsSocialUserRepository>( );
            MockInfluencerRepository = Substitute.For<IInfluencerRepository>( );
            SocialInfoUserRepository = Substitute.For<ISocialInfoUserRepository>( );

            SUT = new InfluencerFacade( MockUserRepository,
                InsightsSocialUserRepository,
                MockInfluencerRepository,
                SocialInfoUserRepository );
        }
    }
}