using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pinf.InstaService.API.InstaFetcher.Filters;
using Pinf.InstaService.API.InstaFetcher.ResponseDtos;

namespace Pinf.InstaService.API.InstaFetcher.Controllers
{
    [ ServiceFilter( typeof( Auth0ActionFilter ), Order = 2 ) ]
    [ ServiceFilter( typeof( FacebookActionFilter ), Order = 3 ) ]
    public abstract class InstagramServiceController : PinfluencerController
    {
    }
}