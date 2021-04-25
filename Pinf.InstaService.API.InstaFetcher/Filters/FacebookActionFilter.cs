using Facebook;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Pinf.InstaService.API.InstaFetcher.ResponseDtos;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Factories;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.DAL.Instagram;
using Pinf.InstaService.DAL.Instagram.Dtos;

namespace Pinf.InstaService.API.InstaFetcher.Filters
{
    //TODO: add factories
    //TODO: validate scopes etc...
    //TODO: middleware should just deal with persisting things to files and validating incoming request!!!!
    public class FacebookActionFilter : ActionFilterAttribute
    {
        private readonly IUserRepository _userRepository;
        private readonly FacebookContext _facebookContext;
        private readonly IFacebookClientFactory _facebookClientFactory;

        public FacebookActionFilter( IUserRepository userRepository,
            FacebookContext facebookContext,
            IFacebookClientFactory facebookClientFactory )
        {
            _userRepository = userRepository;
            _facebookContext = facebookContext;
            _facebookClientFactory = facebookClientFactory;
        }

        public override void OnActionExecuting( ActionExecutingContext context )
        {
            var auth0Id = context.HttpContext.Request.Query[ "auth0_id" ].ToString( );

            if( auth0Id == string.Empty )
            {
                context.Result = new UnauthorizedObjectResult( new ErrorDto
                {
                    ErrorMsg = "'auth0_id' parameter was not present in the request"
                } );
                return;
            }

            var tokenResult = _userRepository.GetInstagramToken( auth0Id );

            if( tokenResult.Status == OperationResultEnum.Failed )
            {
                context.Result = new UnauthorizedObjectResult( new ErrorDto
                {
                    ErrorMsg = "auth0 id did not match an existing user"
                } );
                return;
            }

            _facebookContext.FacebookClient = _facebookClientFactory.Get( tokenResult.Value );

            try
            {
                _facebookContext.FacebookClient.Get( "debug_token",
                    new RequestDebugTokenParams { input_token = tokenResult.Value } );
            }
            catch( FacebookApiException e ) 
            {
                context.Result = new UnauthorizedObjectResult( new ErrorDto
                {
                    ErrorMsg = e.Message
                } ); 
            }
        }
    }
}