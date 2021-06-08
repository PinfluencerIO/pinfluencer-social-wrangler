using NSubstitute;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social;
using Pinfluencer.SocialWrangler.DL.Commands;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.GetInfluencerFromSocialCommandTests
{
    public class Given_A_GetInfluencerFromSocialCommand : DataGivenWhenThen<GetInfluencerFromSocialCommand>
    {
        protected ISocialInfoUserRepository MockSocialInfoUserRepository;
        protected IInsightsSocialUserRepository MockInsightsSocialUserRepository;

        protected override void Given( )
        {
            base.Given( );
            MockSocialInfoUserRepository = Substitute.For<ISocialInfoUserRepository>( );
            MockInsightsSocialUserRepository = Substitute.For<IInsightsSocialUserRepository>( );
            SUT = new GetInfluencerFromSocialCommand( MockSocialInfoUserRepository, MockInsightsSocialUserRepository );
        }
    }
}