using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Enum;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.Common.BubbleHandlerTests.Update.Shared
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
                .Patch( Arg.Any<string>( ), Arg.Any<Dto>( ) );
        }

        [ Test ]
        public void Then_Correct_Endpoint_Is_Reached( )
        {
            MockBubbleClient
                .Received( )
                .Patch( Arg.Is<string>( uri => uri == TestUrl ), Arg.Any<Dto>( ) );
        }

        [ Test ]
        public void Then_Mapping_Is_Valid( )
        {
            MockBubbleClient
                .Received( )
                .Patch( Arg.Any<string>( ), Arg.Is<Dto>( x => x.Id == TestId && x.Value == TestValue ) );
        }

        protected OperationResultEnum SutCall( )
        {
            return BubbleSut.Update( TestUrl, new Model
            {
                Id = TestId,
                Value = TestValue
            }, x => new Dto
            {
                Id = x.Id,
                Value = x.Value
            } );
        }
    }
}