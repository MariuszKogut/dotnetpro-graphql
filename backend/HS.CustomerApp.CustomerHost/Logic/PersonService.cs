using System.Collections.Generic;
using System.Linq;
using HS.CustomerApp.CustomerHost.Contracts;
using HS.CustomerApp.CustomerHost.Models;

namespace HS.CustomerApp.CustomerHost.Logic
{
    public class PersonService : IPersonService
    {
        private readonly List<PersonModel> _data;

        public PersonService(IDataSeeder dataSeeder)
        {
            _data = dataSeeder.Persons;
        }

        public IQueryable<PersonModel> ReadAll() => _data.AsQueryable();

        public IQueryable<PersonModel> ReadByIds(IEnumerable<int> employeesIds) =>
            _data.Where(x => employeesIds.Contains(x.Id)).AsQueryable();

        public PersonModel Read(int id) => _data.FirstOrDefault(x => x.Id == id);

    }
}