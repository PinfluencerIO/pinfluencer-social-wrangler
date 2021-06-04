﻿using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Serialization;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.Crosscutting;

namespace Pinfluencer.SocialWrangler.Crosscutting.Utils
{
    public class PinfluencerJsonResolver : DefaultContractResolver, IContractResolverAdapter
    {
        protected override string ResolvePropertyName( string propertyName )
        {
            if( propertyName.Count( ) == 2 )
            {
                return propertyName;
            }
            return string.Concat(
                    base.ResolvePropertyName( propertyName )
                        .Select( ( x, i ) => i > 0 && char.IsUpper( x ) ? "_" + x : x.ToString( ) ) )
                .ToLower( );
        }

        public IContractResolver Resolver
        {
            get => this;
            set => throw new Exception( );
        }
    }
}