namespace AddressProcessing.Address
{
    public class AddressRecord
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
    }
}
