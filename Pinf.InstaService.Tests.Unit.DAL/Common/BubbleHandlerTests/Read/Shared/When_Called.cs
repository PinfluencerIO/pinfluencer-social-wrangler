using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;

namespace Pinf.InstaService.Tests.Unit.DAL.Common.BubbleHandlerTests.Read.Shared
{
    public abstract class When_Called : Given_A_BubbleHandler
    {
        protected OperationResult<TestModel> Result;
        
        protected const string TestUrl = "test";
        protected const string TestId = "123";
        protected const string TestValue = "value";
        
        [ Test ]
        public void Then_Data_Will_Be_Created_Once( )
        {
            MockBubbleClient
                .Received( 1 )
                .Get<TestDto>( Arg.Any<string>( ) );
        }

        [ Test ]
        public void Then_Correct_Endpoint_Is_Reached( )
        {
            MockBubbleClient
                .Received( )
                .Get<TestDto>( Arg.Is<string>( uri => uri == TestUrl ) );
        }

        protected OperationResult<TestModel> SutCall( ) =>
            BubbleSut.Read<TestModel, TestDto>( TestUrl, x => new TestModel
            {
                Id = x.Id,
                Value = x.Value
            }, new TestModel( ) );
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