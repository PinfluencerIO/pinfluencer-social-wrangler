using System;
using System.Collections.Generic;
using Facebook;
using Microsoft.AspNetCore.Mvc.Filters;
using Pinfluencer.SocialWrangler.API.RequestDtos;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Factories;
using Pinfluencer.SocialWrangler.DAL.Common;
using Pinfluencer.SocialWrangler.DAL.Facebook.Dtos;

namespace Pinfluencer.SocialWrangler.API.Filters
{
    //TODO: add factories
    //TODO: validate scopes etc...
    //TODO: middleware should just deal with persisting things to files and validating incoming request!!!!
    public class FacebookActionFilter : ActionFilterAttribute
    {
        private readonly IFacebookClientFactory _facebookClientFactory;
        private readonly MvcAdapter _mvcAdapter;
        private readonly IFacebookDecorator _facebookDecorator;
        private readonly ITokenRepository _tokenRepository;

        public FacebookActionFilter( IFacebookDecorator facebookDecorator,
            IFacebookClientFactory facebookClientFactory,
            MvcAdapter mvcAdapter, ITokenRepository tokenRepository )
        {
            _facebookDecorator = facebookDecorator;
            _facebookClientFactory = facebookClientFactory;
            _mvcAdapter = mvcAdapter;
            _tokenRepository = tokenRepository;
        }

        public override void OnActionExecuting( ActionExecutingContext context )
        {
            var auth0Id = context.HttpContext.Request.Query[ "auth-id" ].ToString( );

            if( auth0Id == string.Empty )
            {
                try
                {
                    var user = context.ActionArguments[ "user" ];
                    auth0Id = ( ( UserDto ) user ).Auth0Id;
                }
                catch( Exception e ) when ( e is KeyNotFoundException || e is InvalidCastException )
                {
                    context.Result = _mvcAdapter.UnauthorizedError( "'auth-id' parameter was not present in the request" );
                    return;
                }
            }

            var tokenResult = _tokenRepository.Get( auth0Id );

            if( tokenResult.Status == OperationResultEnum.Failed )
            {
                context.Result = _mvcAdapter.UnauthorizedError( "auth0 id did not match an existing user" );
                return;
            }

            _facebookDecorator.Token = tokenResult.Value;

            try
            {
                _facebookDecorator.Get( "debug_token",
                    new RequestDebugTokenParams { input_token = tokenResult.Value } );
            }
            catch( FacebookApiException e )
            {
                context.Result = _mvcAdapter.UnauthorizedError( e.Message );
            }
        }
    }
}