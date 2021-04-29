using System;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Models;
using Pinf.InstaService.Crosscutting.Utils;

namespace Pinf.InstaService.Core.Models.User
{
    public class User : IUser
    {
        private readonly IDateTimeAdapter _dateTimeAdapter;

        public User( IDateTimeAdapter dateTimeAdapter ) { _dateTimeAdapter = dateTimeAdapter; }
        
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Location { get; set; }
        public GenderEnum Gender { get; set; }

        //TODO: ADD LEAP YEAR
        public DateTime Birthday
        {
            set
            {
                var now = int.Parse(_dateTimeAdapter.Now().ToString("yyyyMMdd"));
                var dob = int.Parse(value.ToString("yyyyMMdd"));
                Age = (now - dob) / 10000;
            }
        }
    }
}