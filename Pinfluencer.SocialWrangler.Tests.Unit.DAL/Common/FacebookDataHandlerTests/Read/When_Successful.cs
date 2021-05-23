using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.Common.FacebookDataHandlerTests.Read
{
    public class When_Successful : Given_A_FacebookDataHandler
    {
        private OperationResult<Model> _result;
        private const string Id = "123";
        private const string Value = "321";
        
        protected override void When( )
        {
            MockFacebookClient
                .Get( Arg.Any<string>( ), Arg.Any<object>( ) )
                .Returns( new { id = Id, value = Value } );
            _result = FacebookSut.Read<Model, Dto>( "example", MapOut, new Model( ) );
        }

        [ Test ]
        public void Then_Success_Is_Returned( ) =>
            Assert.AreEqual( OperationResultEnum.Success, _result.Status );

        [ Test ]
        public void Then_Success_Was_Logged( ) =>
            MockLogger
                .Received( 1 )
                .LogInfo( Arg.Any<string>( ) );
    }
}