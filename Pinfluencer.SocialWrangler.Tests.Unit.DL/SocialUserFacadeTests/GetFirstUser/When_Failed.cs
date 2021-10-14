using System.Collections.Generic;
using System.Linq;
using Aidan.Common.Core;
using Aidan.Common.Core.Enum;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Models.Social;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialUserFacadeTests.GetFirstUser
{
    public class When_Failed : Given_A_SocialUserFacade
    {
        private ObjectResult<SocialInsightsUser> _result;

        protected override void When( )
        {
            InsightsSocialUserRepository
                .GetAll( )
                .Returns( new ObjectResult<IEnumerable<SocialInsightsUser>>
                {
                    Status = OperationResultEnum.Failed,
                    Value = Enumerable.Empty<SocialInsightsUser>(  )
                } );
            _result = SUT.GetFirstUser( );
        }

        [ Test ]
        public void Then_Correct_Status_Is_Returned( )
        {
            Assert.AreEqual( OperationResultEnum.Failed, _result.Status );
        }
    }
}