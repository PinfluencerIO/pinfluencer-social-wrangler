using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pinf.InstaService.BLL.Facades;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Crosscutting.Utils;

namespace Pinf.InstaService.API.InstaFetcher.Controllers
{
    //TODO: implement auto-mapper
    [ Route( "instagram_user" ) ]
    public class InstagramUserController : InstagramServiceController
    {
        private readonly InstagramFacade _instagramFacade;
        public InstagramUserController( InstagramFacade instagramFacade, MvcAdapter mvcAdapter ) : base( mvcAdapter ) { _instagramFacade = instagramFacade; }

        [ Route( "" ) ]
        [ HttpGet ]
        public IActionResult GetAll( )
        {
            var users = _instagramFacade.GetUsers( );
            if( users.Status != OperationResultEnum.Failed ) { return MvcAdapter.OkResult( users.Value ); }
            return MvcAdapter.BadRequestError( "failed to fetch instagram users" );
        }
    }
}