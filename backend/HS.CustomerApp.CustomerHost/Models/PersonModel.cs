namespace HS.CustomerApp.CustomerHost.Models
{
    public class PersonModel
    {
        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public AddressModel ResidentialAddress { get; set; }
    }
}