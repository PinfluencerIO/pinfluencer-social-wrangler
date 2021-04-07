﻿using Microsoft.AspNetCore.Http;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Bootstrapping.Services.Enum;
using Pinf.InstaService.Tests.Unit.API.FacebookMiddlware.Shared;

namespace Pinf.InstaService.Tests.Unit.API.FacebookMiddlware
{
    public class When_Successful : When_Auth0_Error_Does_Not_Occur
    {
        protected override void When()
        {
            SetAuth0Id();

            TokenFetchResult = OperationResultEnum.Success;

            base.When();
        }

        [Test]
        public void Then_Next_Middlware_Is_Called()
        {
            MockNextMiddlware
                .Received(1)
                .Invoke(Arg.Any<HttpContext>());
        }
    }
}