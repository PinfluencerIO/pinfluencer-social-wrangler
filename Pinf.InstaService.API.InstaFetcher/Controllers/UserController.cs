using Microsoft.AspNetCore.Mvc;
using Pinf.InstaService.BLL.Core.Enum;
using Pinf.InstaService.BLL.InstagramFetcher.Services;

namespace Pinf.InstaService.API.InstaFetcher.Controllers
{
    //TODO: implement auto-mapper
    [ Route( "user" ) ]
    public class UserController : PinfluencerController
    {
        private readonly InstaUserService _instaUserService;

        public UserController( InstaUserService instaUserService ) { _instaUserService = instaUserService; }

        [ Route( "" ) ]
        public IActionResult GetAll( )
        {
            var users = _instaUserService.GetAll( );
            if( users.Status != OperationResultEnum.Failed ) { return new OkObjectResult( users.Value ); }
            return new BadRequestObjectResult( "failed to fetch instagram users" );
        }

        [ Route( "" ) ]
        [ HttpPost ]
        public IActionResult Create( ) => new OkResult( );
        
    }
}