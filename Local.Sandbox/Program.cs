using System;
using System.Net.Http;
using DAL.Instagram.Dtos;
using DAL.UserManagement.Dtos;
using Facebook;
using Newtonsoft.Json;

namespace Local.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new FacebookClient();

            var accounts = client.Get("me/accounts",new {fields = "instagram_business_account{username,name,biography,followers_count}"});

            var accountsJson = JsonConvert.SerializeObject(accounts);
            
            Console.WriteLine(accountsJson);
            
            var accountsFixedObj = JsonConvert.DeserializeObject<DataArray<FacebookPage>>(accountsJson);

            Console.Read();
        }
    }
}