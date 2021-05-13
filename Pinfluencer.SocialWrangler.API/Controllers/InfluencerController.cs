using Microsoft.AspNetCore.Mvc;
using Pinfluencer.SocialWrangler.API.RequestDtos;
using Pinfluencer.SocialWrangler.BLL.Facades;
using Pinfluencer.SocialWrangler.Core.Enum;

namespace Pinfluencer.SocialWrangler.API.Controllers
{
    //TODO: implement auto-mapper
    [ Route( "influencer" ) ]
    public class InfluencerController : InstagramServiceController
    {
        private readonly InfluencerFacade _influencerFacade;
        
        public InfluencerController( InfluencerFacade influencerFacade, MvcAdapter mvcAdapter ) : base( mvcAdapter ) { _influencerFacade = influencerFacade; }

        [ Route( "" ) ]
        [ HttpPost ]
        public IActionResult Create( [ FromBody ] UserDto user ) => 
            _influencerFacade.OnboardInfluencer( user.UserId ) == OperationResultEnum.Success ?
                MvcAdapter.Success( "influencer created" ) : MvcAdapter.BadRequestError( "influencer not created" ) as IActionResult;
    }
}