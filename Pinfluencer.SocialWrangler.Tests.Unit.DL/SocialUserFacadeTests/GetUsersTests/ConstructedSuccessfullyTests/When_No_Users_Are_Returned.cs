using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialUserFacadeTests.GetUsersTests.FailTests;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialUserFacadeTests.GetUsersTests.
    ConstructedSuccessfullyTests
{
    public class When_No_Users_Are_Returned : When_Get_Insta_Users_Fails
    {
        protected override void When( )
        {            
            InstaUserCollection = Enumerable.Empty<SocialInsightsUser>( );
            InstaUsersOperationResult = OperationResultEnum.Success;

            InsightsSocialUserRepository
                .GetAll( )
                .Returns( new ObjectResult<IEnumerable<SocialInsightsUser>>(
                    InstaUserCollection,
                    InstaUsersOperationResult
                ) );

            Result = SUT.GetUsers( );
        }

        [ Test ]
        public void Then_Insta_User_Array_Is_Empty_Valid( ) { Assert.IsEmpty( Result.Value ); }
    }
}