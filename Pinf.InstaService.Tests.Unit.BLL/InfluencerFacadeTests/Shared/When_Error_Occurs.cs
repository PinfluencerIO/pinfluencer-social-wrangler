using NUnit.Framework;
using Pinf.InstaService.Core.Enum;

namespace Pinf.InstaService.Tests.Unit.BLL.InfluencerFacadeTests.Shared
{
    public abstract class When_Error_Occurs : When_Called
    {
        protected OperationResultEnum Result;

        [ Test ]
        public void Then_Failiure_Was_Returned( )
        {
            Assert.AreEqual( OperationResultEnum.Failed, Result );
        }
    }
}