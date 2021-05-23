using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.Common.BubbleHandlerTests.Read.Shared
{
    public abstract class When_Called : Given_A_BubbleHandler
    {
        protected OperationResult<Model> Result;
        
        protected const string TestUrl = "test";
        protected const string TestId = "123";
        protected const string TestValue = "value";
        
        [ Test ]
        public void Then_Data_Will_Be_Created_Once( )
        {
            MockBubbleClient
                .Received( 1 )
                .Get<Dto>( Arg.Any<string>( ) );
        }

        [ Test ]
        public void Then_Correct_Endpoint_Is_Reached( )
        {
            MockBubbleClient
                .Received( )
                .Get<Dto>( Arg.Is<string>( uri => uri == TestUrl ) );
        }

        protected OperationResult<Model> SutCall( ) =>
            BubbleSut.Read<Model, Dto>( TestUrl, x => new Model
            {
                Id = x.Id,
                Value = x.Value
            }, new Model( ) );
    }
}