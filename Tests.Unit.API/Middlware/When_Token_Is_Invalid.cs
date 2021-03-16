using System;
using System.Threading.Tasks;
using Bootstrapping.Services;
using Bootstrapping.Services.Enum;
using Facebook;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Tests.Unit.API.Middlware.Shared;

namespace Tests.Unit.API.Middlware
{
    public class When_Token_Is_Invalid : When_Auth0_Id_Found_But_Error_Occurs
    {
        protected override void When()
        {
            SetAuth0Id();
            MockFacebookClient
                .Get(Arg.Any<string>(),Arg.Any<object>())
                .Throws<FacebookOAuthException>();

            base.When();
        }
    }
}