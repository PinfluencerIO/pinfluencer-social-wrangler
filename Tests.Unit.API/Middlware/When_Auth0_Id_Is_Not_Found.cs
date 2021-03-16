using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using NSubstitute;
using Tests.Unit.API.Middlware.Shared;

namespace Tests.Unit.API.Middlware
{
    public class When_Auth0_Id_Is_Not_Found : When_Error_Occurs
    {
        protected override void When()
        {
            SetEmptyAuth0Id();
            base.When();
        }
    }
}