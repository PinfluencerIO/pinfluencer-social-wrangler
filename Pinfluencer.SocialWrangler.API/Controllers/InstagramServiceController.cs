using Microsoft.AspNetCore.Mvc;
using Pinfluencer.SocialWrangler.API.Filters;

namespace Pinfluencer.SocialWrangler.API.Controllers
{
    [ ServiceFilter( typeof( Auth0ActionFilter ), Order = 2 ) ]
    [ ServiceFilter( typeof( FacebookActionFilter ), Order = 3 ) ]
    public abstract class InstagramServiceController : PinfluencerController
    {
        protected readonly MvcAdapter MvcAdapter;

        protected InstagramServiceController( MvcAdapter mvcAdapter ) { MvcAdapter = mvcAdapter; }
    }
}