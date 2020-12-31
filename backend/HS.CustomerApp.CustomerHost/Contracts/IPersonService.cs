using System.Collections.Generic;
using System.Linq;
using HS.CustomerApp.CustomerHost.Models;

namespace HS.CustomerApp.CustomerHost.Contracts
{
    public interface IPersonService
    {
        IQueryable<PersonModel> ReadAll();
        IQueryable<PersonModel> ReadByIds(IEnumerable<int> employeesIds);
        PersonModel Read(int id);
    }
}