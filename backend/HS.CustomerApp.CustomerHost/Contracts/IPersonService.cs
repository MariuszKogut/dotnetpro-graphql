using System.Collections.Generic;
using HS.CustomerApp.CustomerHost.Models;

namespace HS.CustomerApp.CustomerHost.Contracts
{
    public interface IPersonService
    {
        IEnumerable<PersonModel> ReadAll();
        IEnumerable<PersonModel> ReadByIds(IEnumerable<int> employeesIds);
        PersonModel Read(int id);
    }
}