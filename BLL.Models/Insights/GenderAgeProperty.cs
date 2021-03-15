using System;

namespace BLL.Models.Insights
{
    public class GenderAgeProperty
    {
        public string Gender { get; }

        public Tuple<int,int> AgeRange { get; private set; }

        public GenderAgeProperty(
            string gender, 
            Tuple<int, int> ageRange
        )
        {
            Gender = gender;
            AgeRange = ageRange;
        }

        private void SetAgeRange(Tuple<int,int> ageRange)
        {
            AgeRange = ageRange;
        }
    }
}