using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pinf.InstaService.BLL.Facades;
using Pinf.InstaService.Core.Enum;

namespace Pinf.InstaService.API.InstaFetcher.Controllers
{
    //TODO: implement auto-mapper
    [ Route( "user" ) ]
    public class UserController : InstagramServiceController
    {
        private readonly InstagramFacade _instagramFacade;
        public UserController( InstagramFacade instagramFacade ) { _instagramFacade = instagramFacade; }

        [ Route( "" ) ]
        public IActionResult GetAll( )
        {
            var users = _instagramFacade.GetUsers( );
            if( users.Status != OperationResultEnum.Failed ) return new OkObjectResult(
                new
                {
                    users = users.Value,
                    multiple = users.Value.Count() > 1,
                    empty = !users.Value.Any()
                } );
            return new BadRequestObjectResult( "failed to fetch instagram users" );
        }

        [ Route( "" ) ]
        [ HttpPost ]
        public IActionResult Create( ) { return new OkResult( ); }
    }
}