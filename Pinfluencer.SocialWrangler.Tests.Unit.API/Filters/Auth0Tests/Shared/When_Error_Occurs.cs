using System.Net;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;

namespace Pinfluencer.SocialWrangler.Tests.Unit.API.Filters.Auth0Tests.Shared
{
    public abstract class When_Error_Occurs : Given_An_Auth0ActionFilter
    {
        [ Test ]
        public void Then_Middlware_Short_Circuits( ) { Assert.NotNull( MockActionExecutingContext.Result ); }

        [ Test ]
        public void Then_Result_Status_Is_Unauthorized( )
        {
            Assert.AreEqual( HttpStatusCode.Unauthorized.GetHashCode( ),
                ( MockActionExecutingContext.Result as ContentResult ).StatusCode );
        }

        [ Test ]
        public void Then_Management_Api_Client_Was_Not_Set( )
        { 
            Auth0ManagementClientDecorator
                .DidNotReceive( )
                .Secret = Arg.Any<string>( ); 
        }
    }
}