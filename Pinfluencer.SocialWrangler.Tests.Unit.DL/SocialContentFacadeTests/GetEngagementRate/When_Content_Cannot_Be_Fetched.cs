using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialContentFacadeTests.GetEngagementRate.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialContentFacadeTests.GetEngagementRate
{
    public class When_Content_Cannot_Be_Fetched : When_Called
    {
        private ObjectResult<double> _result;

        protected override void When( )
        {
            base.When( );
            MockSocialContentRepository
                .GetAll( Arg.Any<string>( ) )
                .Returns( new ObjectResult<IEnumerable<Content>>
                {
                    Status = OperationResultEnum.Failed,
                    Value = Enumerable.Empty<Content>( )
                } );
            _result = SUT.GetEngagementRate( );
        }

        [ Test ]
        public void Then_Failed_Status_Was_Returned( )
        {
            Assert.AreEqual( OperationResultEnum.Failed, _result.Status );
        }
    }
}