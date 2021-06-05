﻿using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Clients;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Factories
{
    public interface IAuthServiceAuthenticationClientDecoratorFactory : IFactory
    {
        IAuthServiceAuthenticationClientDecorator Factory( string domain );
    }
}