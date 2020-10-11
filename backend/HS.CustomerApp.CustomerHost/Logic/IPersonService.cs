using System.Collections.Generic;
using HS.CustomerApp.CustomerHost.Models;

namespace HS.CustomerApp.CustomerHost.Logic
{
    public interface IPersonService
    {
        IEnumerable<PersonModel> ReadAll();
        PersonModel Read(long id);
    }
}