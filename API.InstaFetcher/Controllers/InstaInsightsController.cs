using API.InstaFetcher.Dtos;
using BLL.InstagramFetcher.Services;
using Bootstrapping.Services.Enum;
using Microsoft.AspNetCore.Mvc;

namespace API.InstaFetcher.Controllers
{
    //TODO: implement auto-mapper
    [Route("insta_insights")]
    public class InstaInsightsController : ControllerBase
    {
        private readonly InstaInsightsCollectionService _instaInsightsCollectionService;

        public InstaInsightsController(InstaInsightsCollectionService instaInsightsCollectionService)
        {
            _instaInsightsCollectionService = instaInsightsCollectionService;
        }

        [Route("")]
        public JsonResult GetUser([FromQuery] string user)
        {
            var insights = _instaInsightsCollectionService.GetUserInsights(user);
            if (insights.Status != OperationResultEnum.Failed)
                return new JsonResult(insights.Value);
            var error = new JsonResult(new {error = "failed to fetch instagram impressions for user", message = "user was not found"}) {StatusCode = 400};
            return error;
        }
    }
}