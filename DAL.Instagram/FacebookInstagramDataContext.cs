﻿using Bootstrapping.Services.DataContext;
using DAL.Instagram.Dtos;
using Facebook;
using Newtonsoft.Json;

namespace DAL.Instagram
{
    public class FacebookInstagramDataContext : IInstagramDataContext
    {
        private readonly FacebookClient _facebookClient;

        public FacebookInstagramDataContext(FacebookClient facebookClient)
        {
            _facebookClient = facebookClient;
        }

        public string Get(string url, string fields)
        {
            return JsonConvert.SerializeObject(_facebookClient.Get(url,new RequestFields
            {
                fields=fields
            }));
        }
        
        public string Get<T>(string url, T parameters)
        {
            return JsonConvert.SerializeObject(_facebookClient.Get(url,parameters));
        }
    }
}