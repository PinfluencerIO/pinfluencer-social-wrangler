using System;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Models;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;

namespace Pinfluencer.SocialWrangler.Core.Models.Social
{
    public class SocialInfoUser : ISocialInfoUser
    {
        private readonly IDateTimeAdapter _dateTimeAdapter;

        public SocialInfoUser( IDateTimeAdapter dateTimeAdapter ) { _dateTimeAdapter = dateTimeAdapter; }

        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public LocationProperty Location { get; set; }
        public GenderEnum Gender { get; set; }

        //TODO: ADD LEAP YEAR
        public DateTime Birthday
        {
            set
            {
                if( value == default )
                {
                    Age = -1;
                    return;
                }
                var now = int.Parse( _dateTimeAdapter.Now( ).ToString( "yyyyMMdd" ) );
                var dob = int.Parse( value.ToString( "yyyyMMdd" ) );
                Age = ( now - dob ) / 10000;
            }
        }
    }
}