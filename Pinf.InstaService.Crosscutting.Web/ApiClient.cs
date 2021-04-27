﻿using System;
using System.Net;
using System.Net.Http;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Pinf.InstaService.Crosscutting.Web
{
    public class ApiClient : IApiClient
    {
        private readonly IHttpClient _httpClient;
        
        public ApiClient( IHttpClient httpClient ) { _httpClient = httpClient; }

        public ApiClient( IHttpClient httpClient, Uri uri, string token ) : this( httpClient )
        {
            SetBaseUrl( uri );
            SetBearerToken( token );
        }

        public void SetBaseUrl( Uri uri ) => _httpClient.SetBaseUrl( uri );

        public void SetBearerToken( string token ) => _httpClient.SetBearerToken( token );

        public HttpStatusCode Patch<T>( string uri, T body ) => _httpClient.Patch( uri, JsonConvert.SerializeObject( body ) ).StatusCode;

        public( HttpStatusCode, T ) Get<T>( string uri )
        {
            var result = _httpClient.Get( uri );
            return ( result.StatusCode, JsonConvert.DeserializeObject<T>( result.Content.ReadAsStringAsync( ).Result ) );
        }

        public HttpStatusCode Post<T>( string uri, T body ) => _httpClient.Post( uri, JsonConvert.SerializeObject( body ) ).StatusCode;
    }
}