using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Models.InstaUser;
using Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InstagramFacadeTests.GetUsersTests.Shared;

namespace Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InstagramFacadeTests.GetUsersTests.FailTests
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