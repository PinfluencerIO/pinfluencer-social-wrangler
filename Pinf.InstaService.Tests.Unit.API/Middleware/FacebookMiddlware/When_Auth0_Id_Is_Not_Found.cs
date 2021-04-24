using Pinf.InstaService.Tests.Unit.API.Middleware.FacebookMiddlware.Shared;

namespace Pinf.InstaService.Tests.Unit.API.Middleware.FacebookMiddlware
{
    public class When_Auth0_Id_Is_Not_Found : When_Error_Occurs
    {
        protected override void When( )
        {
            SetEmptyAuth0Id( );
            base.When( );
        }
    }
}