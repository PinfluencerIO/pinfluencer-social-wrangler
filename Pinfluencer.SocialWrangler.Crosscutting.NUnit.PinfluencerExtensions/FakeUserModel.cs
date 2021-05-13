using Pinfluencer.SocialWrangler.Core.Interfaces.Models;
using Pinfluencer.SocialWrangler.Core.Models.User;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;

namespace Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions
{
    public static class FakeUserModel
    {
        public static IUser GetFake( IDateTimeAdapter dateTimeAdapter, FakeUserProps props )
        {
            return new User( dateTimeAdapter )
            {
                Age = props.Age,
                Gender = props.Gender,
                Id = props.Id,
                Location = props.Location,
                Name = props.Name
            };
        }
    }
}