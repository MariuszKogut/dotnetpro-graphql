using System.Collections.Generic;

namespace HS.CustomerApp.CustomerHost.Models
{
    public class CustomerModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public IEnumerable<PersonModel> Persons { get; set; } 
        public long Headquarter { get; set; } 
    }
}