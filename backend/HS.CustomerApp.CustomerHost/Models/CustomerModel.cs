using System.Collections.Generic;

namespace HS.CustomerApp.CustomerHost.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public IEnumerable<int> EmployeesIds { get; set; } 
    }
}