using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pinf.InstaService.API.InstaFetcher.Extensions;
using Pinf.InstaService.API.InstaFetcher.RequestDtos;
using Pinf.InstaService.BLL.Facades;
using Pinf.InstaService.Core.Enum;

namespace Pinf.InstaService.API.InstaFetcher.Controllers
{
    //TODO: implement auto-mapper
    [ Route( "influencer" ) ]
    public class InfluencerController : InstagramServiceController
    {
        private readonly InfluencerFacade _influencerFacade;
        
        public InfluencerController( InfluencerFacade influencerFacade ) { _influencerFacade = influencerFacade; }

        [ Route( "" ) ]
        [ HttpPost ]
        public IActionResult Create( [ FromBody ] UserDto user ) => 
            _influencerFacade.OnboardInfluencer( user.UserId ) == OperationResultEnum.Success ?
                MvcExtensions.Success( "influencer created" ) : MvcExtensions.BadRequestError( "influencer not created" ) as IActionResult;
    }
}