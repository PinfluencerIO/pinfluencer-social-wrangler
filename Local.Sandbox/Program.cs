using System;
using System.Linq;
using System.Net.Http;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Auth0.ManagementApi;
using BLL.InstagramFetcher.Services;
using DAL.Instagram;
using DAL.Instagram.Dtos;
using DAL.Instagram.Repositories;
using Facebook;
using Newtonsoft.Json;

namespace Local.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var authenticationApiClient = new AuthenticationApiClient("DOMAIN");
            
            var token = authenticationApiClient.GetTokenAsync(new ClientCredentialsTokenRequest
            {
                ClientId = "ID",
                ClientSecret = "SECRET",
                Audience = "DOMAIN"
            }).Result;
            
            var apiClient = new ManagementApiClient(token.AccessToken, "DOMAIN", new HttpClientManagementConnection());
            var allClients = apiClient.Users.GetAsync("USER_ID").Result;

            var facebookContext = new FacebookInstagramDataContext(new FacebookClient(allClients.Identities[0].AccessToken));
            
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