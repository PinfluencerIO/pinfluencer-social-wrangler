using Aidan.Common.Core.Enum;
using Aidan.Common.Utils.Web;
using Microsoft.AspNetCore.Mvc.Filters;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social;

namespace Pinfluencer.SocialWrangler.API.Filters
{
    //TODO: factories!!
    //TODO: persist token to file
    //TODO: use transient auth0 context for thread safety, refresh token if expired
    //TODO: validate scopes
    //TODO: middleware should just deal with persisting things to files and validating incoming request!!!!

    public class Auth0ActionFilter : ActionFilterAttribute
    {
        private readonly MvcAdapter _mvcAdapter;
        private readonly IAuthServiceAuthManager _authServiceAuthManager;

        public Auth0ActionFilter( IAuthServiceAuthManager authServiceAuthManager, 
            MvcAdapter mvcAdapter )
        {
            _mvcAdapter = mvcAdapter;
            _authServiceAuthManager = authServiceAuthManager;
        }

        public override void OnActionExecuting( ActionExecutingContext context )
        {
            var result = _authServiceAuthManager.Initialize( );
            if( result.Status == OperationResultEnum.Failed )
            {
                context.Result = _mvcAdapter.UnauthorizedError( result.Msg );
            }
        }
    }
}