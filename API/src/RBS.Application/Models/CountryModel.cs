using RBS.Domain.Countries;

namespace RBS.Application.Models
{
    public class CountryModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string DiallingCode { get; set; }
        public string FlagSrc { get; set; }

        public CountryModel(Country country)
        {
            Id = country.Id;
            Code = country.Code;
            Name = country.Name;
            DiallingCode = country.DiallingCode;
            FlagSrc = country.FlagSrc;
        }
    }
}
