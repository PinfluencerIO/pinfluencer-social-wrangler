using Microsoft.AspNetCore.Mvc;
using Pinf.InstaService.BLL.Core.Enum;
using Pinf.InstaService.BLL.InstagramFetcher.Services;

namespace Pinf.InstaService.API.InstaFetcher.Controllers
{
    //TODO: implement auto-mapper
    [ Route( "user" ) ]
    public class UserController : PinfluencerController
    {
        private readonly InstagramFacade _instagramFacade;
        public UserController( InstagramFacade instagramFacade ) { _instagramFacade = instagramFacade; }

        [ Route( "" ) ]
        public IActionResult GetAll( )
        {
            var users = _instagramFacade.GetUsers( );
            if( users.Status != OperationResultEnum.Failed ) { return new OkObjectResult( users.Value ); }
            return new BadRequestObjectResult( "failed to fetch instagram users" );
        }

        [ Route( "" ) ]
        [ HttpPost ]
        public IActionResult Create( ) => new OkResult( );
        
    }
}