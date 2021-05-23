using System;

namespace Pinfluencer.SocialWrangler.Core
{
    //TODO: MOVE OUT OF DOMAIN AND INTO DAL
    public interface IFacebookDecorator
    {
        public string Token { set; }

        [ Obsolete ]
        public string Get( string url, string fields );

        [ Obsolete ]
        public string Get<T>( string url, T parameters );
        
        public T Get<T>( string url, string fields );

        public TReturn Get<TReturn,TParams>( string url, TParams parameters );
    }
}