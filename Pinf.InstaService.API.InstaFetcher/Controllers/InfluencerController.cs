using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pinf.InstaService.BLL.Facades;
using Pinf.InstaService.Core.Enum;

namespace Pinf.InstaService.API.InstaFetcher.Controllers
{
    //TODO: implement auto-mapper
    [ Route( "influencer" ) ]
    public class InfluencerController : InstagramServiceController
    {
        [ Route( "" ) ]
        [ HttpPost ]
        public IActionResult Create( ) { return new OkResult( ); }
    }
}