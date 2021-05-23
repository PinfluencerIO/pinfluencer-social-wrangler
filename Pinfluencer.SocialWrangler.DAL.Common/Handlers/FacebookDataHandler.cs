using System;
using Facebook;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Handlers;

namespace Pinfluencer.SocialWrangler.DAL.Common.Handlers
{
    public class FacebookDataHandler<T> : IFacebookDataHandler<T>
    {
        private readonly IFacebookDecorator _facebookClient;
        public FacebookDataHandler( IFacebookDecorator facebookClient ) { _facebookClient = facebookClient; }

        public OperationResult<TModel> Read<TModel, TDto>( string resource, Func<TDto, TModel> mapper,
            TModel defaultModel ) =>
            throw new NotImplementedException( );
    }
}