using Microsoft.AspNetCore.Mvc;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.DL.Core.Interfaces.Contract;

namespace Pinfluencer.SocialWrangler.API.Controllers
{
    //TODO: implement auto-mapper
    [ Route( "instagram-user" ) ]
    public class InstagramUserController : SocialWranglerController
    {
        private readonly ISocialFacade _socialFacade;

        public InstagramUserController( ISocialFacade socialFacaade, MvcAdapter mvcAdapter ) : base( mvcAdapter )
        {
            _socialFacade = socialFacaade;
        }

        [ Route( "" ) ]
        [ HttpGet ]
        public IActionResult GetAll( )
        {
            var users = _socialFacade.GetUsers( );
            if( users.Status != OperationResultEnum.Failed ) return MvcAdapter.OkResult( users.Value );
            return MvcAdapter.BadRequestError( "failed to fetch instagram users" );
        }
    }
}