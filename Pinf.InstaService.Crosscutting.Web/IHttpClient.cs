using System;
using System.Net.Http;

namespace Pinf.InstaService.Crosscutting.Web
{
    public interface IHttpClient
    {
        HttpResponseMessage Patch( Uri uri, string body );
    }
}