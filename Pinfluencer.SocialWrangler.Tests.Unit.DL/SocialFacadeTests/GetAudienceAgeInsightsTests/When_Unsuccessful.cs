using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialFacadeTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialFacadeTests.GetAudienceAgeInsightsTests
{
    public class When_Unsuccessful : When_Gender_Age_Audience_Data_Is_Fetched
    {
        private ObjectResult<IEnumerable<AudiencePercentage<AgeProperty>>> _result;

        protected override void When( )
        {
            MockSocialAudienceRepository
                .GetGenderAge( Arg.Any<string>( ) )
                .Returns( new ObjectResult<IEnumerable<AudienceCount<GenderAgeProperty>>>(
                    Enumerable.Empty<AudienceCount<GenderAgeProperty>>( ),
                    OperationResultEnum.Failed
                ) );
            _result = SUT.GetAudienceAgeInsights( "123" );
        }

        [ Test ]
        public void Then_Failiure_Is_Returned( ) { Assert.AreEqual( OperationResultEnum.Failed, _result.Status ); }

        [ Test ]
        public void Then_Empty_Collection_Is_Returned( ) { Assert.IsEmpty( _result.Value ); }
    }
}