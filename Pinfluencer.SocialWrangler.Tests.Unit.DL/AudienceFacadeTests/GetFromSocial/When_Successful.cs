using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.Tests.Unit.DL.AudienceFacadeTests.GetFromSocial.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.AudienceFacadeTests.GetFromSocial
{
    public class When_Successful : When_Called
    {
        private ObjectResult<Audience> _result;
        public const string TestUserId = "123432";

        protected override void When( )
        {
            base.When( );
            _result = SUT.GetFromSocial( );
        }

        [ Test ]
        public void Then_Correct_Audience_Was_Returned( )
        {
            CollectionAssert.AreEquivalent( new []
                {
                    ( 0.2, 18, 24 ),
                    ( 0.8, 25, 36 )
                },
                _result
                    .Value
                    .AudienceAge
                    .Select( x => ( x.Percentage, x.Value.Min, x.Value.Max ) ) );
            CollectionAssert.AreEquivalent( new []
                {
                    ( 0.4, GenderEnum.Male ), 
                    ( 0.6, GenderEnum.Female )
                },
                _result
                    .Value
                    .AudienceGender
                    .Select( x => ( x.Percentage, x.Value ) ) );
            CollectionAssert.AreEquivalent( new []
                {
                    ( 0.2, CountryEnum.GB, "United Kingdom" ), 
                    ( 0.8, CountryEnum.US, "United States" )
                },
                _result
                    .Value
                    .AudienceCountry
                    .Select( x => ( x.Percentage, x.Value.CountryCode, x.Value.Country ) ) );
            Assert.AreEqual( 25, _result.Value.Reach );
            Assert.AreEqual( 123, _result.Value.Impressions );
            Assert.AreEqual( 0.8, _result.Value.EngagementRate );
        }

        [ Test ]
        public void Then_Correct_Audience_Age_Insights_Are_Fetched( )
        {
            MockSocialAudienceFacade
                .Received( )
                .GetAudienceAgeInsights( TestUserId );
            MockSocialAudienceFacade
                .Received( 1 )
                .GetAudienceAgeInsights( Arg.Any<string>( ) );
        }
        
        [ Test ]
        public void Then_Correct_Audience_Country_Insights_Are_Fetched( )
        {
            MockSocialAudienceFacade
                .Received( )
                .GetAudienceCountryInsights( TestUserId );
            MockSocialAudienceFacade
                .Received( 1 )
                .GetAudienceCountryInsights( Arg.Any<string>( ) );
        }
        
        [ Test ]
        public void Then_Correct_Audience_Gender_Insights_Are_Fetched( )
        {
            MockSocialAudienceFacade
                .Received( )
                .GetAudienceGenderInsights( TestUserId );
            MockSocialAudienceFacade
                .Received( 1 )
                .GetAudienceGenderInsights( Arg.Any<string>( ) );
        }
        
        [ Test ]
        public void Then_Correct_Impressions_Insights_Are_Fetched( )
        {
            MockSocialContentFacade
                .Received( )
                .GetImpressions( TestUserId );
            MockSocialContentFacade
                .Received( 1 )
                .GetImpressions( Arg.Any<string>( ) );
        }
        
        [ Test ]
        public void Then_Correct_Reach_Insights_Are_Fetched( )
        {
            MockSocialContentFacade
                .Received( )
                .GetReach( TestUserId );
            MockSocialContentFacade
                .Received( 1 )
                .GetReach( Arg.Any<string>( ) );
        }

        [ Test ]
        public void Then_Result_Is_Successful( )
        {
            ResultAssert.IsSuccess( _result );
        }
    }
}