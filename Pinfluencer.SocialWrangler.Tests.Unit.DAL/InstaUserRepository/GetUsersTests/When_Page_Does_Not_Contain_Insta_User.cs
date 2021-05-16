using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Social;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstaUserRepository.GetUsersTests
{
    public class When_Page_Does_Not_Contain_Insta_User : When_Get_Users_Is_Called
    {
        private OperationResult<IEnumerable<SocialInsightsUser>> _result;

        protected override void When( )
        {
            SetEmptyPage( );

            base.When( );

            _result = Sut.GetAll( );
        }

        [ Test ]
        public void Then_The_Response_Is_Empty( ) { Assert.IsEmpty( _result.Value ); }

        [ Test ]
        public void Then_The_Status_Is_Success( ) { Assert.AreEqual( OperationResultEnum.Success, _result.Status ); }
        
        [ Test ]
        public void Then_Success_Is_Logged( )
        {
            MockLogger
                .Received( )
                .LogInfo( Arg.Any<string>( ) );
        }
    }
}