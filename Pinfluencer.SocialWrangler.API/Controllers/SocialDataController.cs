using Microsoft.AspNetCore.Mvc;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.DL.Core.Interfaces.Contract;

namespace Pinfluencer.SocialWrangler.API.Controllers
{
    [ Route( "social-data" ) ]
    public class SocialDataController : SocialWranglerController
    {
        private readonly IAudienceFacade _audienceFacade;
        private readonly IGetInfluencerFromSocialCommand _getInfluencerFromSocialCommand;

        public SocialDataController( IAudienceFacade audienceFacade, MvcAdapter mvcAdapter, IGetInfluencerFromSocialCommand getInfluencerFromSocialCommand ) : base( mvcAdapter )
        {
            _audienceFacade = audienceFacade;
            _getInfluencerFromSocialCommand = getInfluencerFromSocialCommand;
        }
        
        [ Route( "" ) ]
        [ HttpGet ]
        public IActionResult GetAll( )
        {
            var audienceResult = _audienceFacade.GetFromSocial( );
            var influencerResult = _getInfluencerFromSocialCommand.Run( );
            if( audienceResult.Status == OperationResultEnum.Failed || 
                influencerResult.Status == OperationResultEnum.Failed ) return MvcAdapter.BadRequestError( "failed to fetch social data" );
            return MvcAdapter.OkResult( new
            {
                Audience = audienceResult.Value,
                Influencer = influencerResult.Value
            } );

        }
    }
}