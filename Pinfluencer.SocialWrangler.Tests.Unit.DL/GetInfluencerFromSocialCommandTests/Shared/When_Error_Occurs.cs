using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.User;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.GetInfluencerFromSocialCommandTests.Shared
{
    public abstract class When_Error_Occurs : When_Called
    {
        protected ObjectResult<Influencer> Result;

        [ Test ]
        public void Then_Failiure_Was_Returned( ) { Assert.AreEqual( OperationResultEnum.Failed, Result.Status ); }
    }
}