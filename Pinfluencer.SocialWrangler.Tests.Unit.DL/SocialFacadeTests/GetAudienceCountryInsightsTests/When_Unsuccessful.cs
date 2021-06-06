using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialFacadeTests.GetAudienceCountryInsightsTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialFacadeTests.GetAudienceCountryInsightsTests
{
    public class When_Unsuccessful : When_Called
    {
        private ObjectResult<IEnumerable<AudiencePercentage<CountryProperty>>> _result;

        protected override void When( )
        {
            MockSocialAudienceCountryRepository
                .Get( Arg.Any<string>( ) )
                .Returns( new ObjectResult<IEnumerable<AudienceCount<CountryProperty>>>(
                    Enumerable.Empty<AudienceCount<CountryProperty>>( ),
                    OperationResultEnum.Failed
                ) );
            _result = SUT.GetAudienceCountryInsights( InstagramId );
        }

        [ Test ]
        public void Then_Failiure_Is_Returned( ) { Assert.AreEqual( OperationResultEnum.Failed, _result.Status ); }

        [ Test ]
        public void Then_Empty_Collection_Is_Returned( ) { Assert.IsEmpty( _result.Value ); }
    }
}