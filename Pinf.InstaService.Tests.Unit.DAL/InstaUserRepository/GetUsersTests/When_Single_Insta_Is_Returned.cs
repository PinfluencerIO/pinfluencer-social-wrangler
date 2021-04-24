using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Pinf.InstaService.BLL.Core;
using Pinf.InstaService.BLL.Core.Enum;
using Pinf.InstaService.BLL.Models.InstaUser;

namespace Pinf.InstaService.Tests.Unit.DAL.InstaUserRepository.GetUsersTests
{
    public class When_Single_Insta_Is_Returned : When_Get_Users_Is_Called
    {
        private OperationResult<IEnumerable<InstaUser>> _result;

        protected override void When( )
        {
            SetSingleInsta( "12321", "user", "Aidan Gan", "this is my bio", 121 );

            base.When( );

            _result = Sut.GetUsers( );
        }

        [ Test ]
        public void Then_Id_Is_Correct( ) { Assert.AreEqual( "12321", _result.Value.First( ).Identity.Id ); }

        [ Test ]
        public void Then_Name_Is_Correct( ) { Assert.AreEqual( "Aidan Gan", _result.Value.First( ).Name ); }

        [ Test ]
        public void Then_Handle_Is_Correct( ) { Assert.AreEqual( "user", _result.Value.First( ).Identity.Handle ); }

        [ Test ]
        public void Then_Bio_Is_Correct( ) { Assert.AreEqual( "this is my bio", _result.Value.First( ).Bio ); }

        [ Test ]
        public void Then_Followers_Are_Correct( ) { Assert.AreEqual( 121, _result.Value.First( ).Followers ); }

        [ Test ]
        public void Then_The_Status_Is_Successful( ) { Assert.AreEqual( OperationResultEnum.Success, _result.Status ); }
    }
}