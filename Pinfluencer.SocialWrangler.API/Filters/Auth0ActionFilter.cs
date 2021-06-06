using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Options;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Clients;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Factories;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer;

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