using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core.Enum;

namespace Pinf.InstaService.Tests.Unit.DAL.Common.BubbleHandlerTests.Update.Shared
{
    public abstract class When_Called : Given_A_BubbleHandler
    {
        protected const string TestUrl = "test";
        protected const string TestId = "123";
        protected const string TestValue = "value";
        
        [ Test ]
        public void Then_Data_Will_Be_Created_Once( )
        {
            MockBubbleClient
                .Received( 1 )
                .Patch( Arg.Any<string>( ), Arg.Any<TestDto>( ) );
        }

        [ Test ]
        public void Then_Correct_Endpoint_Is_Reached( )
        {
            MockBubbleClient
                .Received( )
                .Patch( Arg.Is<string>( uri => uri == TestUrl ), Arg.Any<TestDto>( ) );
        }

        [ Test ]
        public void Then_Mapping_Is_Valid( )
        {
            MockBubbleClient
                .Received( )
                .Patch( Arg.Any<string>( ), Arg.Is<TestDto>( x => x.Id == TestId && x.Value == TestValue ) );
        }

        protected OperationResultEnum SutCall( ) =>
            Sut.Update( TestUrl, new TestModel
            {
                Id = TestId,
                Value = TestValue
            }, x => new TestDto
            {
                Id = x.Id,
                Value = x.Value
            } );
    }

    public class TestModel
    {
        public string Id { get; set; }
        public string Value { get; set; }
    }
    
    public class TestDto
    {
        public string Id { get; set; }
        public string Value { get; set; }
    }
}