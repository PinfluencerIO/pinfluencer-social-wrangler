using NSubstitute;
using Pinfluencer.SocialWrangler.DL.Facades;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Pinfluencer;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social;

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