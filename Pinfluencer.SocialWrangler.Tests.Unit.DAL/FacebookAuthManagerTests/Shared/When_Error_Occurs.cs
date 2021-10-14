using Aidan.Common.Core.Enum;
using NUnit.Framework;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.FacebookAuthManagerTests.Shared
{
    public abstract class When_Error_Occurs : Given_A_FacebookAuthManager
    {
        [ Test ]
        public void Then_Error_Is_Returned( ) { Assert.AreEqual( OperationResultEnum.Failed, Result.Status ); }
    }
}