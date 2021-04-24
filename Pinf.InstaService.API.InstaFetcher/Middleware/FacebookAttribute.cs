using System.Threading.Tasks;
using Facebook;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Pinf.InstaService.BLL.Core.Enum;
using Pinf.InstaService.BLL.Core.Factories;
using Pinf.InstaService.BLL.Core.Repositories;
using Pinf.InstaService.DAL.Instagram;
using Pinf.InstaService.DAL.Instagram.Dtos;

namespace Pinf.InstaService.API.InstaFetcher.Middleware
{
    //TODO: add factories
    //TODO: validate scopes etc...
    //TODO: create generic error handler
    //TODO: middleware should just deal with persisting things to files and validating incoming request!!!!
    public class FacebookAttribute : ActionFilterAttribute, IActionFilter
    {
        private readonly IUserRepository _userRepository;
        private readonly FacebookContext _facebookContext;
        private readonly IFacebookClientFactory _facebookClientFactory;

        public FacebookAttribute( IUserRepository userRepository,
            FacebookContext facebookContext,
            IFacebookClientFactory facebookClientFactory )
        {
            _userRepository = userRepository;
            _facebookContext = facebookContext;
            _facebookClientFactory = facebookClientFactory;
        }

        public void Invoke(
            HttpContext context
        )
        {
            var auth0Id = context.Request.Query[ "auth0_id" ].ToString( );

            //if( auth0Id == string.Empty )
                // HandleError( context, "request must have query param of auth0_id" );

            var tokenResult = _userRepository.GetInstagramToken( auth0Id );

            //if( tokenResult.Status == OperationResultEnum.Failed )
                //auth0 error, cannot access user token

            _facebookContext.FacebookClient = _facebookClientFactory.Get( tokenResult.Value );

            try
            {
                _facebookContext.FacebookClient.Get( "debug_token",
                    new RequestDebugTokenParams { input_token = tokenResult.Value } );
            }
            catch( FacebookApiException e ) { /*ERROR*/ }
        }

        public override void OnActionExecuting( ActionExecutingContext context )
        {
            //TODO: implement
        }
    }
}