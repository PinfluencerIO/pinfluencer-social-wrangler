using System.Collections.Generic;
using System.Net;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Pinfluencer.SocialWrangler.API.Core.Dtos.Response;
using Pinfluencer.SocialWrangler.Crosscutting.Core.Interfaces.Contract;

namespace Pinfluencer.SocialWrangler.API
{
    public class MvcAdapter
    {
        private readonly ISerializer _serializer;

        public MvcAdapter( ISerializer serializer ) { _serializer = serializer; }

        public IActionResult Success( string message ) { return Ok( new SuccessDto { Msg = message } ); }

        public IActionResult NotFoundError( string message ) { return NotFound( new ErrorDto { ErrorMsg = message } ); }

        public IActionResult UnauthorizedError( string message )
        {
            return Unauthorized( new ErrorDto { ErrorMsg = message } );
        }

        public IActionResult BadRequestError( string message )
        {
            return BadRequest( new ErrorDto { ErrorMsg = message } );
        }

        public IActionResult OkResult<T>( IEnumerable<T> collection )
        {
            return Ok( new CollectionDto<T> { Collection = collection } );
        }

        public IActionResult OkResult<T>( T objectVal ) { return Ok( objectVal ); }

        private ContentResult Ok( object objectValue ) { return ToJson( objectValue, HttpStatusCode.OK ); }

        private ContentResult BadRequest( object objectValue )
        {
            return ToJson( objectValue, HttpStatusCode.BadRequest );
        }

        private ContentResult Unauthorized( object objectValue )
        {
            return ToJson( objectValue, HttpStatusCode.Unauthorized );
        }

        private ContentResult NotFound( object objectValue ) { return ToJson( objectValue, HttpStatusCode.NotFound ); }

        private ContentResult ToJson( object objectValue, HttpStatusCode statusCode )
        {
            var json = _serializer.Serialize( objectValue );
            return new ContentResult
            {
                Content = json,
                ContentType = MediaTypeNames.Application.Json,
                StatusCode = statusCode.GetHashCode( )
            };
        }
    }
}