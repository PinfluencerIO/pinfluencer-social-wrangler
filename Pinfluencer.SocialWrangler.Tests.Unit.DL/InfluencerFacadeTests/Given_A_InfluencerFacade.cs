using Aidan.Common.Core.Enum;
using NSubstitute;
using Pinfluencer.SocialWrangler.DL.Facades;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Pinfluencer;
using Pinfluencer.SocialWrangler.DL.Core.Interfaces.Contract;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.InfluencerFacadeTests
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
        
        protected IInfluencerRepository MockInfluencerRepository;
        protected IUserRepository MockUserRepository;
        protected IGetInfluencerFromSocialCommand MockGetInfluencerFromSocialCommand;

        protected override void Given( )
        {
            MockUserRepository = Substitute.For<IUserRepository>( );
            MockInfluencerRepository = Substitute.For<IInfluencerRepository>( );
            MockGetInfluencerFromSocialCommand = Substitute.For<IGetInfluencerFromSocialCommand>( );

            SUT = new InfluencerFacade( MockUserRepository,
                MockInfluencerRepository,
                MockGetInfluencerFromSocialCommand );
        }
    }
}