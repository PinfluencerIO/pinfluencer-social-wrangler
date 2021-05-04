using System.Collections.Generic;
using System.Net;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Pinf.InstaService.API.InstaFetcher.ResponseDtos;
using Pinf.InstaService.Crosscutting.Utils;

namespace Pinf.InstaService.API.InstaFetcher
{
    public class MvcAdapter
    {
        private readonly ISerializer _serializer;

        public MvcAdapter( ISerializer serializer ) { _serializer = serializer; }
        
        public IActionResult Success( string message ) => Ok( new SuccessDto{ Msg = message } );

        public IActionResult NotFoundError( string message ) => NotFound( new ErrorDto { ErrorMsg = message } );
        
        public IActionResult UnauthorizedError( string message ) => Unauthorized( new ErrorDto { ErrorMsg = message } );

        public IActionResult BadRequestError( string message ) => BadRequest( new ErrorDto { ErrorMsg = message } );

        public IActionResult OkResult<T>( IEnumerable<T> collection ) => Ok( new CollectionDto<T> { Collection = collection } );

        public IActionResult OkResult<T>( T objectVal ) => Ok( objectVal );

        public ContentResult Ok( object objectValue ) => ToJson( objectValue, HttpStatusCode.OK );

        public ContentResult BadRequest( object objectValue ) => ToJson( objectValue, HttpStatusCode.BadRequest );

        public ContentResult Unauthorized( object objectValue ) => ToJson( objectValue,HttpStatusCode.Unauthorized );

        public ContentResult NotFound( object objectValue ) => ToJson( objectValue, HttpStatusCode.NotFound );

        private ContentResult ToJson( object objectValue, HttpStatusCode statusCode )
        {
            var json = _serializer.Serialzie( objectValue );
            return new ContentResult
            {
                Content = json,
                ContentType = MediaTypeNames.Application.Json,
                StatusCode = statusCode.GetHashCode( )
            };
        }
    }
}