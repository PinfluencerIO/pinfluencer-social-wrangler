using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Social;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialFacadeTests.GetUsersTests.Shared
{
    public abstract class When_Get_All_Is_Called : Given_An_InstagramFacade
    {
        protected OperationResultEnum InstaUsersOperationResult { set; get; }
        protected IEnumerable<SocialInsightsUser> InstaUserCollection { set; get; }

        protected override void When( )
        {
            InsightsSocialUserRepository
                .GetAll( )
                .Returns( new ObjectResult<IEnumerable<SocialInsightsUser>>(
                    InstaUserCollection,
                    InstaUsersOperationResult
                ) );
        }

        [ Test ]
        public void Then_Get_Insta_Users_Was_Called_Once( )
        {
            InsightsSocialUserRepository
                .Received( 1 )
                .GetAll( );
        }
    }
}