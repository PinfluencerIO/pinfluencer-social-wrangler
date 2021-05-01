using Pinf.InstaService.Core.Interfaces.Models;
using Pinf.InstaService.Core.Models.User;
using Pinf.InstaService.Crosscutting.Utils;

namespace Pinf.InstaService.Crosscutting.NUnit.PinfluencerExtensions
{
    public static class FakeUserModel
    {
        public static IUser GetFake( IDateTimeAdapter dateTimeAdapter, FakeUserProps props )
        {
            return new User( dateTimeAdapter )
            {
                Age = props.Age,
                Birthday = props.Birthday,
                BirthdayString = props.BirthdayString,
                Gender = props.Gender,
                GenderString = props.GenderString,
                Id = props.Id,
                Location = props.Location,
                Name = props.Name
            };
        }
    }
}