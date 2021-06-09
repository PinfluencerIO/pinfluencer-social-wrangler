using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;

namespace Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions
{
    public static class ResultAssert
    {
        public static void IsSuccess<T>( ObjectResult<T> result )
        {
            Assert.AreEqual( OperationResultEnum.Success, result.Status );
        }
        
        public static void IsWarning<T>( ObjectResult<T> result )
        {
            Assert.AreEqual( OperationResultEnum.Warning, result.Status );
        }
        
        public static void IsFailiure<T>( ObjectResult<T> result )
        {
            Assert.AreEqual( OperationResultEnum.Failed, result.Status );
        }
    }
}