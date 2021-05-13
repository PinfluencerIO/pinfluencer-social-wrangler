using System;
using Pinfluencer.SocialWrangler.Core.Enum;

namespace Pinfluencer.SocialWrangler.Core.Interfaces.Models
{
    public interface IUser
    {
        string Id { get; set; }
        string Name { get; set; }
        int Age { get; set; }
        string Location { get; set; }
        GenderEnum Gender { get; set; }
        DateTime Birthday { set; }
    }
}