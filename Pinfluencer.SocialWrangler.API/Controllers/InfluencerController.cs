using Aidan.Common.Core.Enum;
using Aidan.Common.Utils.Web;
using Microsoft.AspNetCore.Mvc;
using Pinfluencer.SocialWrangler.API.Core.Dtos.Request;
using Pinfluencer.SocialWrangler.DL.Core.Interfaces.Contract;

namespace Pinfluencer.SocialWrangler.API.Controllers
{
    //TODO: implement auto-mapper
    [ Route( "influencer" ) ]
    public class InfluencerController : SocialWranglerController
    {
        private readonly IInfluencerFacade _influencerFacade;
        private readonly IGetInfluencerFromSocialCommand _getInfluencerFromSocialCommand;

        public InfluencerController( IInfluencerFacade influencerFacade,
            MvcAdapter mvcAdapter,
            IGetInfluencerFromSocialCommand getInfluencerFromSocialCommand ) : base( mvcAdapter )
        {
            _influencerFacade = influencerFacade;
            _getInfluencerFromSocialCommand = getInfluencerFromSocialCommand;
        }

        [ Route( "" ) ]
        [ HttpPost ]
        public IActionResult Create( [ FromBody ] UserDto user )
        {
            return _influencerFacade.Onboard( user.UserId ) == OperationResultEnum.Success
                ? MvcAdapter.Success( "influencer created" )
                : MvcAdapter.BadRequestError( "influencer not created" );
        }
        
        [ Route( "" ) ]
        [ HttpGet ]
        public IActionResult Get( )
        {
            var influencerStatus = _getInfluencerFromSocialCommand.Run( );
            return influencerStatus.Status == OperationResultEnum.Success
                ? MvcAdapter.OkResult( influencerStatus.Value )
                : MvcAdapter.BadRequestError( "influencer not fetched" );
        }
    }
}