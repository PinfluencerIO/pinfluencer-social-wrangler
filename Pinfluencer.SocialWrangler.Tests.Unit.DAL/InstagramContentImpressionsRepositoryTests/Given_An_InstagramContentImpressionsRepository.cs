using NSubstitute;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Handlers;
using Pinfluencer.SocialWrangler.DAL.Facebook.Repositories;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramContentImpressionsRepositoryTests
{
    public class
        Given_An_InstagramContentImpressionsRepository : DataGivenWhenThen<InstagramContentImpressionsRepository>
    {
        protected IInstagramInsightsDataHandler<ContentImpressions> MockInstagramInsightsDataHandler;

        protected override void Given( )
        {
            base.Given( );
            MockInstagramInsightsDataHandler = Substitute.For<IInstagramInsightsDataHandler<ContentImpressions>>( );
            SUT = new InstagramContentImpressionsRepository( MockInstagramInsightsDataHandler );
        }
    }
}