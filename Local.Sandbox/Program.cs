using System;
using System.Net.Http;
using DAL.UserManagement.Dtos;
using Newtonsoft.Json;

namespace Local.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var auth0User = new Auth0User
            {
                Id = "1232134",
                Identities = new[]
                {
                    new Identity
                    {
                        Token =
                            "4mXxJZ"
                    }
                }
            };
            
            Console.WriteLine(JsonConvert.SerializeObject(auth0User));

            Console.Read();
        }
    }
}