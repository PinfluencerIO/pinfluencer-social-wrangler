using System;
using Pinf.InstaService.Core.Enum;

namespace Pinf.InstaService.Core.Interfaces.Models
{
    public interface IUser
    {
        string Id { get; set; }
        string Name { get; set; }
        int Age { get; set; }
        string Location { get; set; }
        GenderEnum Gender { get; set; }
        DateTime Birthday { set; }
        string BirthdayString { set; }
        string GenderString { set; }
    }
}