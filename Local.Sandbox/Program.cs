using System;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using API.InstaFetcher.Dtos;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Auth0.ManagementApi;
using AutoMapper;
using BLL.InstagramFetcher.Services;
using BLL.Models.InstaUser;
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
            var users = new InstaUserIdentityCollection(new []{ new InstaUserIdentity("1234","12345") },true,true);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<InstaIdentityCollectionDto,InstaUserIdentityCollection>());
            var mapper = config.CreateMapper();
            var dto = mapper.Map<InstaUserIdentityCollection>(users);
        }
    }
}