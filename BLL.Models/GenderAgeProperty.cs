using System;

namespace BLL.Models
{
    public class GenderAgeProperty
    {
        public string Gender { get; }

        public Tuple<int,int> AgeRange { get; }

        public GenderAgeProperty(string gender, Tuple<int, int> ageRange)
        {
            Gender = gender;
            AgeRange = ageRange;
        }
    }
}