using Microsoft.AspNetCore.Mvc;
using Pinfluencer.SocialWrangler.API.Core.Dtos.Request;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.DL.Core.Interfaces.Contract;

namespace Pinfluencer.SocialWrangler.API.Controllers
{
    //TODO: implement auto-mapper
    [ Route( "influencer" ) ]
    public class InfluencerController : SocialWranglerController
    {
        private readonly IInfluencerFacade _influencerFacade;

        public InfluencerController( IInfluencerFacade influencerFacade, MvcAdapter mvcAdapter ) : base( mvcAdapter )
        {
            _influencerFacade = influencerFacade;
        }

        [ Route( "" ) ]
        [ HttpPost ]
        public IActionResult Create( [ FromBody ] UserDto user )
        {
            return _influencerFacade.OnboardInfluencer( user.UserId ) == OperationResultEnum.Success
                ? MvcAdapter.Success( "influencer created" )
                : MvcAdapter.BadRequestError( "influencer not created" );
        }
    }
}