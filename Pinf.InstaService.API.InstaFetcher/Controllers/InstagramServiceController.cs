using Microsoft.AspNetCore.Mvc;
using Pinf.InstaService.API.InstaFetcher.Filters;

namespace Pinf.InstaService.API.InstaFetcher.Controllers
{
    [ ServiceFilter( typeof( FacebookAttribute ) ) ]
    public abstract class InstagramServiceController : PinfluencerController
    {
    }
}