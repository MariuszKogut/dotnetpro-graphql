using System.Collections.Generic;
using System.Linq;
using HS.CustomerApp.CustomerHost.Models;

namespace HS.CustomerApp.CustomerHost.Contracts
{
    public interface IAddressService
    {
        IQueryable<AddressModel> ReadAll();
        AddressModel Read(long id);
    }
}