using Microsoft.AspNetCore.Mvc;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.BuisnessLayer;

namespace Pinfluencer.SocialWrangler.API.Controllers
{
    //TODO: implement auto-mapper
    [ Route( "instagram-user" ) ]
    public class InstagramUserController : SocialWranglerController
    {
        private readonly IInstagramFacade _instagramFacade;

        public InstagramUserController( IInstagramFacade instagramFacaade, MvcAdapter mvcAdapter ) : base( mvcAdapter )
        {
            _instagramFacade = instagramFacaade;
        }

        [ Route( "" ) ]
        [ HttpGet ]
        public IActionResult GetAll( )
        {
            var users = _instagramFacade.GetUsers( );
            if( users.Status != OperationResultEnum.Failed ) return MvcAdapter.OkResult( users.Value );
            return MvcAdapter.BadRequestError( "failed to fetch instagram users" );
        }
    }
}