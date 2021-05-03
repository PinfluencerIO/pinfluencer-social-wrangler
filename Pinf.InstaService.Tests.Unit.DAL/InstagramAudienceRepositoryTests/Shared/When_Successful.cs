using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core.Enum;

namespace Pinf.InstaService.Tests.Unit.DAL.InstagramAudienceRepositoryTests.Shared
{
    public abstract class When_Successful<T> : When_Any_Called<T>
    {
        [ Test ]
        public void Then_Success_Event_Is_Logged( )
        {
            MockLogger
                .Received( )
                .LogInfo( Arg.Any<string>( ) );
        }
        
        [ Test ]
        public void Then_Success_Was_Returned( )
        {
            Assert.AreEqual( OperationResultEnum.Success, Result.Status );
        }
    }
}