using System;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialContentFacadeTests.GetImpressionsTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialContentFacadeTests.GetImpressionsTests.
    ConstructedSuccessfullyTests
{
    [ TestFixture ]
    public class When_Successful : When_Called
    {
        private ObjectResult<int> _result;

        protected override void When( )
        {
            ImpressionsColleciton = GetSingleImpressionsColleciton( new DateTime( 2000, 1, 1 ), 5 );
            ImpressionsOperationResult = OperationResultEnum.Success;

            base.When( );

            _result = SUT.GetImpressions( TestId );
        }

        [ Test ]
        public void Then_Impressions_Count_Are_Correct( ) { Assert.AreEqual( 5, _result.Value ); }

        [ Test ]
        public void Then_Result_Status_Is_Success( ) { Assert.AreEqual( OperationResultEnum.Success, _result.Status ); }
    }
}