using System.Collections.Generic;
using HS.CustomerApp.CustomerHost.Models;

namespace HS.CustomerApp.CustomerHost.Logic
{
    public interface IAddressService
    {
        IEnumerable<AddressModel> ReadAll();
        AddressModel Read(long id);
    }
}