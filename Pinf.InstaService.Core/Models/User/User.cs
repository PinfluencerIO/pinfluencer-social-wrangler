using System;
using Pinf.InstaService.Core.Enum;

namespace Pinf.InstaService.Core.Models.User
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Location { get; set; }
        public GenderEnum Gender { get; set; }
    }
}