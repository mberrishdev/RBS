using RBS.Domain.Addresses;

namespace RBS.Application.Models
{
    public class AddressModel
    {
        public int? Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }

        public AddressModel(Address address)
        {
            Id = address?.Id;
            Country = address?.Country;
            City = address?.City;
            Street = address?.Street;
            Number = address?.Number;
        }

    }
}
