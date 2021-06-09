using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Filters;
using Pinfluencer.SocialWrangler.API.Core.Constants;
using Pinfluencer.SocialWrangler.API.Core.Dtos.Request;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social;

namespace Pinfluencer.SocialWrangler.API.Filters
{
    //TODO: add factories
    //TODO: validate scopes etc...
    //TODO: middleware should just deal with persisting things to files and validating incoming request!!!!
    public class FacebookActionFilter : ActionFilterAttribute
    {
        private readonly MvcAdapter _mvcAdapter;
        private readonly ISocialAuthManager _socialAuthManager;

        public FacebookActionFilter( MvcAdapter mvcAdapter,
            ISocialAuthManager socialAuthManager )
        {
            _mvcAdapter = mvcAdapter;
            _socialAuthManager = socialAuthManager;
        }

        public override void OnActionExecuting( ActionExecutingContext context )
        {
            var auth0Id = context.HttpContext.Request.Query[ MvcConstants.Auth0IdKey ].ToString( );

            if( auth0Id == string.Empty )
            {
                try
                {
                    var user = context.ActionArguments[ "user" ];
                    auth0Id = ( ( UserDto ) user ).Auth0Id;
                }
                catch( Exception e ) when( e is KeyNotFoundException || e is InvalidCastException )
                {
                    context.Result =
                        _mvcAdapter.UnauthorizedError(
                            $"'{MvcConstants.Auth0IdKey}' parameter was not present in the request" );
                    return;
                }
            }

            var result = _socialAuthManager.Initialize( auth0Id );
            if( result.Status == OperationResultEnum.Failed )
            {
                context.Result = _mvcAdapter.UnauthorizedError( result.Msg );
            }
        }
    }
}