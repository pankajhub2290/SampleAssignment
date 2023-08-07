namespace SampleAssignment.Domain.Common
{
    public class Address
    {
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public Address() { }

        public Address(string addressLine1, string addressLine2, string city, string state, string country, string postalCode)
        {
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            City = city;
            State = state;
            Country = country;
            PostalCode = postalCode;
        }

    }
}
