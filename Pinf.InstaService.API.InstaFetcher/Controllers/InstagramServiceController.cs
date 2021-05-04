using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pinf.InstaService.API.InstaFetcher.Filters;
using Pinf.InstaService.API.InstaFetcher.ResponseDtos;
using Pinf.InstaService.Crosscutting.Utils;

namespace Pinf.InstaService.API.InstaFetcher.Controllers
{
    [ ServiceFilter( typeof( Auth0ActionFilter ), Order = 2 ) ]
    [ ServiceFilter( typeof( FacebookActionFilter ), Order = 3 ) ]
    public abstract class InstagramServiceController : PinfluencerController
    {
        protected readonly MvcAdapter MvcAdapter;

        protected InstagramServiceController( MvcAdapter mvcAdapter ) { MvcAdapter = mvcAdapter; }
    }
}