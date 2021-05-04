using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Pinf.InstaService.API.InstaFetcher.ResponseDtos;

namespace Pinf.InstaService.API.InstaFetcher.Extensions
{
    public static class MvcExtensions
    {
        public static IActionResult Success( string message ) => new SuccessDto{ Msg = message }.Ok( );

        public static IActionResult NotFoundError( string message ) => new ErrorDto { ErrorMsg = message }.NotFound( );
        
        public static IActionResult UnauthorizedError( string message ) => new ErrorDto { ErrorMsg = message }.Unauthorized( );

        public static IActionResult BadRequestError( string message ) => new ErrorDto { ErrorMsg = message }.BadRequest( );

        public static IActionResult OkResult<T>( this IEnumerable<T> collection ) => new CollectionDto<T> { Collection = collection }.Ok( );

        public static IActionResult OkResult<T>( this T objectVal ) => objectVal.Ok( );
        
        [ Description( "newtonsoft json formatter" ) ]
        private static ContentResult ToJson( this object objectValue, HttpStatusCode statusCode )
        {
            var json = JsonConvert.SerializeObject( objectValue );
            return new ContentResult
            {
                Content = json,
                ContentType = MediaTypeNames.Application.Json,
                StatusCode = statusCode.GetHashCode( )
            };
        }

        private static ContentResult Ok( this object objectValue ) => objectValue.ToJson( HttpStatusCode.OK );
        
        private static ContentResult BadRequest( this object objectValue ) => objectValue.ToJson( HttpStatusCode.BadRequest );
        
        private static ContentResult Unauthorized( this object objectValue ) => objectValue.ToJson( HttpStatusCode.Unauthorized );
        
        private static ContentResult NotFound( this object objectValue ) => objectValue.ToJson( HttpStatusCode.NotFound );
    }
}