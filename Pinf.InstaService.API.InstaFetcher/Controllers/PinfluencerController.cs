using Microsoft.AspNetCore.Mvc;
using Pinf.InstaService.API.InstaFetcher.Filters;

namespace Pinf.InstaService.API.InstaFetcher.Controllers
{
    [ ServiceFilter( typeof( SimpleAuthActionFilter ), Order = 1 ) ]
    public abstract class PinfluencerController : ControllerBase
    {
    }
}