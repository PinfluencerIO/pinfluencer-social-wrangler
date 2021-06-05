using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.ManagementApi.Models;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.FacebookTokenRepositoryTests.GetInstagramTokenTests.Shared
{
    public abstract class When_Called : Given_A_FacebookTokenRepository
    {
        protected const string Id = "1234";
        protected User User;

        protected override void When( )
        {
            MockAuth0ManagementApiConnection
                .GetAsync<User>( Arg.Any<Uri>( ), Arg.Any<IDictionary<string, string>>( ),
                    Arg.Any<JsonConverter [ ]>( ) )
                .Returns( Task.FromResult( User ) );
        }

        [ Test ]
        public void Then_Get_User_Is_Called_Once( )
        {
            MockAuth0ManagementApiConnection
                .Received( 1 )
                .GetAsync<User>( Arg.Any<Uri>( ), Arg.Any<IDictionary<string, string>>( ),
                    Arg.Any<JsonConverter [ ]>( ) );
        }

        [ Test ]
        //TODO: flaky test
        public void Then_Valid_User_Is_Retrieved( )
        {
            MockAuth0ManagementApiConnection
                .Received( )
                .GetAsync<User>( Arg.Is<Uri>( x => x.AbsolutePath.Contains( Id ) ),
                    Arg.Any<IDictionary<string, string>>( ), Arg.Any<JsonConverter [ ]>( ) );
        }
    }
}