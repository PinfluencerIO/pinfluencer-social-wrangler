﻿using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Social;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstaUserRepository.GetUsersTests
{
    public class When_Multiple_Users_Are_Returned : When_Get_Users_Is_Called
    {
        private OperationResult<IEnumerable<SocialInsightsUser>> _result;

        protected override void When( )
        {
            SetTwoInsta(
                "12321", "user", "Aidan Gan", "this is my bio", 121,
                "543543", "user2", "David Gan", "this is not my bio", 321
            );

            base.When( );

            _result = Sut.GetAll( );
        }

        [ Test ]
        public void Then_Ids_Are_Correct( )
        {
            Assert.IsTrue( new [ ] { "12321", "543543" }.SequenceEqual( _result.Value.Select( x => x.Id ) ) );
        }

        [ Test ]
        public void Then_Names_Are_Correct( )
        {
            Assert.IsTrue( new [ ] { "Aidan Gan", "David Gan" }.SequenceEqual( _result.Value.Select( x => x.Name ) ) );
        }

        [ Test ]
        public void Then_Handles_Are_Correct( )
        {
            Assert.IsTrue(
                new [ ] { "user", "user2" }.SequenceEqual( _result.Value.Select( x => x.Username ) ) );
        }

        [ Test ]
        public void Then_Bios_Are_Correct( )
        {
            Assert.IsTrue(
                new [ ] { "this is my bio", "this is not my bio" }.SequenceEqual(
                    _result.Value.Select( x => x.Bio ) ) );
        }

        [ Test ]
        public void Then_Followers_Are_Correct( )
        {
            Assert.IsTrue( new [ ] { 121, 321 }.SequenceEqual( _result.Value.Select( x => x.Followers ) ) );
        }

        [ Test ]
        public void Then_The_Status_Is_Successful( ) { Assert.AreEqual( OperationResultEnum.Success, _result.Status ); }
        
        [ Test ]
        public void Then_Success_Is_Logged( )
        {
            MockLogger
                .Received( )
                .LogInfo( Arg.Any<string>( ) );
        }
    }
}