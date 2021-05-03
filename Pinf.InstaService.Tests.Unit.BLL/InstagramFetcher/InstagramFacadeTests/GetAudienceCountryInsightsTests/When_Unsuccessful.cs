using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Models.Insights;
using Pinf.InstaService.Crosscutting.Utils;

namespace Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InstagramFacadeTests.GetAudienceCountryInsightsTests
{
    public class When_Unsuccessful : Given_An_InstagramFacade
    {
        private OperationResult<IEnumerable<AudiencePercentage<RegionInfo>>> _result;

        protected override void When( )
        {
            MockInstaAudienceInsightsRepository
                .GetCountry( Arg.Any<string>(  ) )
                .Returns( new OperationResult<IEnumerable<FollowersInsight<RegionInfo>>>(
                    Enumerable.Empty<FollowersInsight<RegionInfo>>(  ), 
                    OperationResultEnum.Failed
                ) );
            _result = Sut.GetAudienceCountryInsights( "123" );
        }

        [ Test ]
        public void Then_Success_Is_Returned( )
        {
            Assert.AreEqual( OperationResultEnum.Failed, _result.Status );
        }
        
        [ Test ]
        public void Then_Empty_Collection_Is_Returned( )
        {
            Assert.IsEmpty( _result.Value );
        }
    }
}