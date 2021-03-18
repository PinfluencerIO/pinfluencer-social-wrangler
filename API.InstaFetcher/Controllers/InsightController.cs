using BLL.InstagramFetcher.Services;
using Bootstrapping.Services.Enum;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.InstaFetcher.Controllers
{
    //TODO: implement auto-mapper
    [Route("insight")]
    public class InsightController : ControllerBase
    {
        private readonly InstaInsightsCollectionService _instaInsightsCollectionService;

        public InsightController(InstaInsightsCollectionService instaInsightsCollectionService)
        {
            _instaInsightsCollectionService = instaInsightsCollectionService;
        }

        [Route("")]
        public JsonResult GetUserInsights([FromQuery] string user)
        {
            var insights = _instaInsightsCollectionService.GetUserInsights(user);
            if (insights.Status != OperationResultEnum.Failed)
                return new JsonResult(insights.Value);
            var error = new JsonResult(new {error = "failed to fetch instagram impressions for user", message = "user was not found"}) {StatusCode = 400};
            return error;
        }
    }
}