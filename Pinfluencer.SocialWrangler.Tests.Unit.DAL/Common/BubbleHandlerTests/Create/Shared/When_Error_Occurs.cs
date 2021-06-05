using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Enum;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.Common.BubbleHandlerTests.Create.Shared
{
    public abstract class When_Error_Occurs : When_Called
    {
        protected OperationResultEnum Result;

        [ Test ]
        public void Then_Failiure_Is_Returned( ) { Assert.AreEqual( OperationResultEnum.Failed, Result ); }

        [ Test ]
        public void Then_Error_Is_Logged( )
        {
            MockLogger
                .Received( )
                .LogError( Arg.Any<string>( ) );
        }
    }
}