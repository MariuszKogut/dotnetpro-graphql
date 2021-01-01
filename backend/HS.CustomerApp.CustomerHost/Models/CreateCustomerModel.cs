using System.Collections.Generic;

namespace HS.CustomerApp.CustomerHost.Models
{
    public class CreateCustomerModel
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public IEnumerable<int> EmployeesIds { get; set; } 
    }
}