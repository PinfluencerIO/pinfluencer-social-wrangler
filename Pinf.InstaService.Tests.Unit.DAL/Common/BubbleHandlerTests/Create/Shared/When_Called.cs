using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble;
using Pinf.InstaService.Tests.Unit.DAL.AudienceRepositoryTests;

namespace Pinf.InstaService.Tests.Unit.DAL.Common.BubbleHandlerTests.Create.Shared
{
    public abstract class When_Called : Given_A_BubbleHandler
    {
        protected const string TestUrl = "test";
        
        [ Test ]
        public void Then_Data_Will_Be_Created_Once( )
        {
            MockBubbleClient
                .Received( 1 )
                .Post( Arg.Any<string>( ), Arg.Any<TestModel>( ) );
        }

        [ Test ]
        public void Then_Correct_Endpoint_Is_Reached( )
        {
            MockBubbleClient
                .Received( )
                .Post( Arg.Is<string>( uri => uri == TestUrl ), Arg.Any<TestModel>( ) );
        }
    }

    public class TestModel
    {
    }
}