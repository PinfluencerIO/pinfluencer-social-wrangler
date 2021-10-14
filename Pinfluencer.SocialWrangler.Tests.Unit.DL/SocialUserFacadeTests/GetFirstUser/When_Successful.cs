using System.Collections.Generic;
using Aidan.Common.Core;
using Aidan.Common.Core.Enum;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Models.Social;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialUserFacadeTests.GetFirstUser
{
    [ TestFixtureSource( nameof( _data ) ) ]
    public class When_Successful : Given_A_SocialUserFacade
    {
        private const string Id = "123321";
        private const string Bio = "this is an example";
        private const int Followers = 121;
        private const string Name = "Aidna Gannon";
        private const string Username = "aidangannon";
        
        private static object [ ] _data =
        {
            new object [ ]
            {
                new [ ]
                {
                    new SocialInsightsUser
                    {
                        Id = "123321",
                        Bio = "this is an example",
                        Followers = 121,
                        Name = "Aidna Gannon",
                        Username = "aidangannon"
                    }
                }
            },
            new object [ ]
            {
                new [ ]
                {
                    new SocialInsightsUser
                    {
                        Id = Id,
                        Bio = Bio,
                        Followers = Followers,
                        Name = Name,
                        Username = Username
                    },
                    new SocialInsightsUser
                    {
                        Id = "54353",
                        Bio = "this is another example",
                        Followers = 323,
                        Name = "James Gannon",
                        Username = "jamesgannon"
                    }
                }
            }
        };

        private ObjectResult<SocialInsightsUser> _result;
        private readonly IEnumerable<SocialInsightsUser> _users;

        public When_Successful( IEnumerable<SocialInsightsUser> users ) { _users = users; }

        protected override void When( )
        {
            InsightsSocialUserRepository
                .GetAll( )
                .Returns( new ObjectResult<IEnumerable<SocialInsightsUser>>
                {
                    Status = OperationResultEnum.Success,
                    Value = _users
                } );
            _result = SUT.GetFirstUser( );
        }
        
        [ Test ]
        public void Then_Correct_Status_Is_Returned( )
        {
            Assert.AreEqual( OperationResultEnum.Success, _result.Status );
        }
        
        [ Test ]
        public void Then_Correct_User_Is_Returned( )
        {
            Assert.AreEqual( Id, _result.Value.Id );
            Assert.AreEqual( Name, _result.Value.Name );
            Assert.AreEqual( Username, _result.Value.Username );
            Assert.AreEqual( Followers, _result.Value.Followers );
            Assert.AreEqual( Bio, _result.Value.Bio );
        }
    }
}