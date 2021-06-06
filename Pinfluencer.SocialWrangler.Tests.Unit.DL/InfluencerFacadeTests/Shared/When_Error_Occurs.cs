using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Enum;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.InfluencerFacadeTests.Shared
{
    public abstract class When_Error_Occurs : When_Called
    {
        protected OperationResultEnum Result;

        [ Test ]
        public void Then_Failiure_Was_Returned( ) { Assert.AreEqual( OperationResultEnum.Failed, Result ); }
    }
}