using System;
using System.Linq;
using System.Net.Http;
using BLL.InstagramFetcher.Services;
using DAL.Instagram;
using DAL.Instagram.Dtos;
using DAL.Instagram.Repositories;
using DAL.UserManagement.Dtos;
using Facebook;
using Newtonsoft.Json;

namespace Local.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var facebookContext = new FacebookContext(new FacebookClient(""));
            
            var insightsService =
                new InstaInsightsCollectionService(
                    new FacebookInstaImpressionsRepository(facebookContext));
            
            var userService =
                new InstaUserService(
                    new FacebookInstaUserRepository(facebookContext));

            var users = userService.GetAll();
            
            var insights = insightsService.GetUserInsights(users.Value.InstaUserIdentities.First().Id);
        }
    }
}