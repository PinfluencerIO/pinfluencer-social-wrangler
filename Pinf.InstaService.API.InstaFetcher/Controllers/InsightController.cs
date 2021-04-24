﻿using Microsoft.AspNetCore.Mvc;
using Pinf.InstaService.API.InstaFetcher.ResponseDtos;
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
        public IActionResult GetUserInsights( [ FromQuery ] string user )
        {
            var insights = _instaInsightsCollectionService.GetUserInsights( user );
            if( insights.Status != OperationResultEnum.Failed ) { return new OkObjectResult( insights.Value ); }
            return new BadRequestObjectResult( new ErrorDto{ ErrorMsg = "failed to fetch instagram impressions for user" } );
        }
    }
}