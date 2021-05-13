using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.InstaUser;

namespace Pinfluencer.SocialWrangler.Tests.Unit.BLL.InstagramFacadeTests.GetUsersTests.Shared
{
    public abstract class When_Get_All_Is_Called : Given_An_InstagramFacade
    {
        protected OperationResultEnum InstaUsersOperationResult { set; get; }
        protected IEnumerable<InstaUser> InstaUserCollection { set; get; }

        protected override void When( )
        {
            MockSocialUserRepository
                .GetAll( )
                .Returns( new OperationResult<IEnumerable<InstaUser>>(
                    InstaUserCollection,
                    InstaUsersOperationResult
                ) );
        }

        [ Test ]
        public void Then_Get_Insta_Users_Was_Called_Once( )
        {
            MockSocialUserRepository
                .Received( 1 )
                .GetAll( );
        }
    }
}