using Microsoft.AspNetCore.Mvc;
using Pinf.InstaService.BLL.Core.Enum;
using Pinf.InstaService.BLL.InstagramFetcher.Services;

namespace Pinf.InstaService.API.InstaFetcher.Controllers
{
    //TODO: implement auto-mapper
    [ Route( "insight" ) ]
    public class InsightController : PinfluencerController
    {
        private readonly InstaInsightsCollectionService _instaInsightsCollectionService;

        public InsightController( InstaInsightsCollectionService instaInsightsCollectionService )
        {
            _instaInsightsCollectionService = instaInsightsCollectionService;
        }

        [ Route( "" ) ]
        public JsonResult GetUserInsights( [ FromQuery ] string user )
        {
            var insights = _instaInsightsCollectionService.GetUserInsights( user );
            if( insights.Status != OperationResultEnum.Failed )
                return new JsonResult( insights.Value );
            var error = new JsonResult( new
                    { error = "failed to fetch instagram impressions for user", message = "user was not found" } )
                { StatusCode = 400 };
            return error;
        }
    }
}