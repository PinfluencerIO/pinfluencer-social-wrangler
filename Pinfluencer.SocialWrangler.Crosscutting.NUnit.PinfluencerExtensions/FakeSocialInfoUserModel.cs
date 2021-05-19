using Pinfluencer.SocialWrangler.Core.Interfaces.Models;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.Core.Models.User;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;

namespace Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions
{
    public static class FakeSocialInfoUserModel
    {
        public static ISocialInfoUser GetFake( IDateTimeAdapter dateTimeAdapter, FakeSocialInfoUserProps props )
        {
            return new SocialInfoUser( dateTimeAdapter )
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