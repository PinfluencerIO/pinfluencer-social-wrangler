using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Tests.Unit.BLL.InstagramFacadeTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.BLL.InstagramFacadeTests.GetAudienceGenderInsightsTests
{
    public class When_Unsuccessful : When_Gender_Age_Audience_Data_Is_Fetched
    {
        private OperationResult<IEnumerable<AudiencePercentage<GenderEnum>>> _result;

        protected override void When( )
        {
            MockSocialAudienceRepository
                .GetGenderAge( Arg.Any<string>( ) )
                .Returns( new OperationResult<IEnumerable<AudienceCount<GenderAgeProperty>>>(
                    Enumerable.Empty<AudienceCount<GenderAgeProperty>>( ),
                    OperationResultEnum.Failed
                ) );
            _result = SUT.GetAudienceGenderInsights( "123" );
        }

        [ Test ]
        public void Then_Failiure_Is_Returned( ) { Assert.AreEqual( OperationResultEnum.Failed, _result.Status ); }

        [ Test ]
        public void Then_Empty_Collection_Is_Returned( ) { Assert.IsEmpty( _result.Value ); }
    }
}