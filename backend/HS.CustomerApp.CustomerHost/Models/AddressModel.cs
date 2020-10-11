namespace HS.CustomerApp.CustomerHost.Models
{
    public class AddressModel
    {
        public long Id { get; set; }
        public string Street { get; set; }
        public string StreetNo { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}