using Microsoft.AspNetCore.Mvc;
using Pinf.InstaService.BLL.Core.Enum;
using Pinf.InstaService.BLL.InstagramFetcher.Services;

namespace Pinf.InstaService.API.InstaFetcher.Controllers
{
    //TODO: implement auto-mapper
    [ Route( "user" ) ]
    public class UserController : ControllerBase
    {
        private readonly InstaUserService _instaUserService;

        public UserController( InstaUserService instaUserService ) { _instaUserService = instaUserService; }

        [ Route( "" ) ]
        public JsonResult GetAll( )
        {
            var users = _instaUserService.GetAll( );
            if ( users.Status != OperationResultEnum.Failed )
                return new JsonResult( users.Value );
            var error = new JsonResult( new { error = "failed to fetch instagram users", message = "spurious error" } )
                { StatusCode = 500 };
            return error;
        }

        [ Route( "" ) ]
        [ HttpPost ]
        public JsonResult Create( )
        {
            return new JsonResult( new { status = "profile being created" } ) { StatusCode = 200 };
        }
    }
}