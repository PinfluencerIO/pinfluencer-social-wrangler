using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.Tests.Unit.DL.InstagramFacadeTests.GetUsersTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.InstagramFacadeTests.GetUsersTests.FailTests
{
    public class When_Get_Insta_Users_Fails : When_Get_All_Is_Called
    {
        private ObjectResult<IEnumerable<SocialInsightsUser>> _result;

        protected override void When( )
        {
            InstaUserCollection = Enumerable.Empty<SocialInsightsUser>( );
            InstaUsersOperationResult = OperationResultEnum.Failed;

            base.When( );

            _result = SUT.GetUsers( );
        }

        [ Test ]
        public void Then_Operation_Result_Fails( ) { Assert.AreEqual( OperationResultEnum.Failed, _result.Status ); }
    }
}