using System;
using Aidan.Common.Core.Attributes;
using Aidan.Common.Core.Enum;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing
{
    [ Service( Scope = ServiceLifetimeEnum.Scoped ) ]
    public interface IFacebookDecorator
    {
        [ Obsolete ]
        public string Get( string url, string fields );

        [ Obsolete ]
        public string Get<T>( string url, T parameters );

        public T Get<T>( string url, string fields );

        public TReturn Get<TReturn>( string url, object parameters );
        
        public string Token { set; }
    }
}