using NSubstitute;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Handlers;
using Pinfluencer.SocialWrangler.DAL.Facebook.Repositories;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramContentReachRepositoryTests
{
    public class
        Given_An_InstagramContentReachRepository : DataGivenWhenThen<InstagramContentReachRepository>
    {
        protected IInstagramInsightsDataHandler<ContentReach> MockInstagramInsightsDataHandler;

        protected override void Given( )
        {
            base.Given( );
            MockInstagramInsightsDataHandler = Substitute.For<IInstagramInsightsDataHandler<ContentReach>>( );
            SUT = new InstagramContentReachRepository( MockInstagramInsightsDataHandler );
        }
    }
}