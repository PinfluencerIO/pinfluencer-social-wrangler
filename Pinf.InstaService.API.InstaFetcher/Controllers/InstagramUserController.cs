using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pinf.InstaService.BLL.Facades;
using Pinf.InstaService.Core.Enum;

namespace Pinf.InstaService.API.InstaFetcher.Controllers
{
    //TODO: implement auto-mapper
    [ Route( "instagram_user" ) ]
    public class InstagramUserController : InstagramServiceController
    {
        private readonly InstagramFacade _instagramFacade;
        public InstagramUserController( InstagramFacade instagramFacade ) { _instagramFacade = instagramFacade; }

        [ Route( "" ) ]
        [ HttpGet ]
        public IActionResult GetAll( )
        {
            var users = _instagramFacade.GetUsers( );
            if( users.Status != OperationResultEnum.Failed )
                return new OkObjectResult(
                    new
                    {
                        users = users.Value,
                        multiple = users.Value.Count( ) > 1,
                        empty = !users.Value.Any( )
                    } );
            return new BadRequestObjectResult( "failed to fetch instagram users" );
        }
    }
}