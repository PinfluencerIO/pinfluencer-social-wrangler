using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core.Enum;

namespace Pinf.InstaService.Tests.Unit.DAL.Common.BubbleHandlerTests.Read.Shared
{
    public abstract class When_Error_Occurs : When_Called
    {
        [ Test ]
        public void Then_Failiure_Is_Returned( ) { Assert.AreEqual( OperationResultEnum.Failed, Result.Status ); }
        
        [ Test ]
        public void Then_Error_Is_Logged( )
        {
            MockLogger
                .Received( )
                .LogError( Arg.Any<string>( ) );
        }
    }
}