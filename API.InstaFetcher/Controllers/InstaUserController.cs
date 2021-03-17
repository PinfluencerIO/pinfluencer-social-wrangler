using System.Linq;
using API.InstaFetcher.Dtos;
using AutoMapper;
using BLL.InstagramFetcher.Services;
using BLL.Models.InstaUser;
using Bootstrapping.Services.Enum;
using Microsoft.AspNetCore.Mvc;

namespace API.InstaFetcher.Controllers
{
    [Route("insta_user")]
    public class InstaUserController : ControllerBase
    {
        private readonly InstaUserService _instaUserService;

        public InstaUserController(InstaUserService instaUserService)
        {
            _instaUserService = instaUserService;
        }

        [Route("")]
        public JsonResult GetAll()
        {
            var users = _instaUserService.GetAll();

            if (users.Status != OperationResultEnum.Failed)
                return new JsonResult(users.Value);
            var error = new JsonResult(new {error = "failed to fetch instagram users"}) {StatusCode = 400};
            return error;
        }
    }
}