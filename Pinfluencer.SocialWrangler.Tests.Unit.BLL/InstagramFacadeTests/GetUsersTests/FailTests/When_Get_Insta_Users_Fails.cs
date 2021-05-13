﻿using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.InstaUser;
using Pinfluencer.SocialWrangler.Tests.Unit.BLL.InstagramFacadeTests.GetUsersTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.BLL.InstagramFacadeTests.GetUsersTests.FailTests
{
    public class When_Get_Insta_Users_Fails : When_Get_All_Is_Called
    {
        private OperationResult<IEnumerable<InstaUser>> _result;

        protected override void When( )
        {
            InstaUserCollection = Enumerable.Empty<InstaUser>( );
            InstaUsersOperationResult = OperationResultEnum.Failed;

            base.When( );

            _result = Sut.GetUsers( );
        }

        [ Test ]
        public void Then_Operation_Result_Fails( ) { Assert.AreEqual( OperationResultEnum.Failed, _result.Status ); }
    }
}