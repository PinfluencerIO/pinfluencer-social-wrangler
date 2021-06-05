﻿using System;
using System.Collections.Generic;
using Facebook;
using Microsoft.AspNetCore.Mvc.Filters;
using Pinfluencer.SocialWrangler.API.RequestDtos;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Factories;
using Pinfluencer.SocialWrangler.DAL.Facebook.Dtos;

namespace Pinfluencer.SocialWrangler.API.Filters
{
    //TODO: add factories
    //TODO: validate scopes etc...
    //TODO: middleware should just deal with persisting things to files and validating incoming request!!!!
    public class FacebookActionFilter : ActionFilterAttribute
    {
        private readonly IFacebookDecoratorFactory _facebookDecoratorFactory;
        private readonly MvcAdapter _mvcAdapter;
        private readonly ITokenRepository _tokenRepository;

        public FacebookActionFilter( IFacebookDecoratorFactory facebookDecoratorFactory,
            MvcAdapter mvcAdapter,
            ITokenRepository tokenRepository )
        {
            _facebookDecoratorFactory = facebookDecoratorFactory;
            _mvcAdapter = mvcAdapter;
            _tokenRepository = tokenRepository;
        }

        public override void OnActionExecuting( ActionExecutingContext context )
        {
            var auth0Id = context.HttpContext.Request.Query[ "auth-id" ].ToString( );

            if( auth0Id == string.Empty )
                try
                {
                    var user = context.ActionArguments[ "user" ];
                    auth0Id = ( ( UserDto ) user ).Auth0Id;
                }
                catch( Exception e ) when( e is KeyNotFoundException || e is InvalidCastException )
                {
                    context.Result =
                        _mvcAdapter.UnauthorizedError( "'auth-id' parameter was not present in the request" );
                    return;
                }

            var tokenResult = _tokenRepository.Get( auth0Id );

            if( tokenResult.Status == OperationResultEnum.Failed )
            {
                context.Result = _mvcAdapter.UnauthorizedError( "auth0 id did not match an existing user" );
                return;
            }

            var facebookDecorator = _facebookDecoratorFactory
                .Factory( tokenResult.Value );

            try
            {
                facebookDecorator.Get( "debug_token",
                    new RequestDebugTokenParams { input_token = tokenResult.Value } );
            }
            catch( FacebookApiException e ) { context.Result = _mvcAdapter.UnauthorizedError( e.Message ); }
        }
    }
}