﻿using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialFacadeTests.GetImpressionsTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialFacadeTests.GetImpressionsTests.
    FailTests
{
    public class When_Insights_Fails_To_Be_Returned : When_Called
    {
        private ObjectResult<IEnumerable<ContentImpressions>> _result;

        protected override void When( )
        {
            ImpressionsOperationResult = OperationResultEnum.Failed;

            ImpressionsColleciton = Enumerable.Empty<ContentImpressions>( );

            base.When( );

            _result = SUT.GetImpressions( TestId );
        }

        [ Test ]
        public void Then_Empty_Impressions_Are_Returned( ) { Assert.IsEmpty( _result.Value ); }

        [ Test ]
        public void Then_Return_Status_Is_Fail( ) { Assert.AreEqual( OperationResultEnum.Failed, _result.Status ); }
    }
}