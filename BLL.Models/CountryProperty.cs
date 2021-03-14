namespace BLL.Models
{
    public class CountryProperty
    {
        public string CountryCode { get; }

        public CountryProperty(string countryCode)
        {
            CountryCode = countryCode;
        }
    }
}