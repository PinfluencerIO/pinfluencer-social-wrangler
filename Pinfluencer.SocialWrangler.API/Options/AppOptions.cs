﻿using System;

namespace Pinfluencer.SocialWrangler.API.Options
{
    public class AppOptions : IDisposable
    {
        public Auth0Options Auth0 { get; set; }
        public BubbleOptions Bubble { get; set; }
        public void Dispose( ) { throw new NotImplementedException( ); }
    }
}