using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.Common.FacebookDataHandlerTests.Read
{
    public class When_Successful : Given_A_FacebookDataHandler
    {
        private const string Id = "123";
        private const string Value = "321";
        private ObjectResult<Model> _result;

        protected override void When( )
        {
            MockFacebookDecorator
                .Get<Dto>( Arg.Any<string>( ), Arg.Any<object>( ) )
                .Returns( new Dto{ Id = Id, Value = Value } );
            _result = FacebookSut.Read<Model, Dto>( "example", MapOut, new Model( ) );
        }

        [ Test ]
        public void Then_Success_Is_Returned( ) { Assert.AreEqual( OperationResultEnum.Success, _result.Status ); }

        [ Test ]
        public void Then_Success_Was_Logged( )
        {
            MockLogger
                .Received( 1 )
                .LogInfo( Arg.Any<string>( ) );
        }
    }
}