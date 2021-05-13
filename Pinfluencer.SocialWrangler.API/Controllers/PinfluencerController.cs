using Microsoft.AspNetCore.Mvc;
using Pinfluencer.SocialWrangler.API.Filters;

namespace Pinfluencer.SocialWrangler.API.Controllers
{
    [ ServiceFilter( typeof( SimpleAuthActionFilter ), Order = 1 ) ]
    public abstract class PinfluencerController : ControllerBase
    {
    }
}