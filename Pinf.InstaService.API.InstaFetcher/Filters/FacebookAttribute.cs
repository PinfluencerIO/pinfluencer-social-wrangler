using Auth0.ManagementApi.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Pinf.InstaService.BLL.Core.Factories;
using Pinf.InstaService.BLL.Core.Repositories;
using Pinf.InstaService.DAL.Instagram;

namespace Pinf.InstaService.API.InstaFetcher.Filters
{
    public class FacebookAttribute : ActionFilterAttribute, IActionFilter
    {
        private readonly IUserRepository _userRepository;
        private readonly FacebookContext _facebookContext;
        private readonly IFacebookClientFactory _facebookClientFactory;
        
        public FacebookAttribute( IUserRepository userRepository, FacebookContext facebookContext, IFacebookClientFactory facebookClientFactory )
        {
            _userRepository = userRepository;
            _facebookContext = facebookContext;
            _facebookClientFactory = facebookClientFactory;
        }

        public override void OnActionExecuting( ActionExecutingContext context )
        {
            
        }
    }
}