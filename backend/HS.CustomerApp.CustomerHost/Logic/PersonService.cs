using System.Collections.Generic;
using System.Linq;
using Bogus;
using HS.CustomerApp.CustomerHost.Models;

namespace HS.CustomerApp.CustomerHost.Logic
{
    public class PersonService : IPersonService
    {
        private List<PersonModel> _data = new List<PersonModel>();

        public PersonService()
        {
            SeedSampleData();
        }

        public IEnumerable<PersonModel> ReadAll() => _data;

        public PersonModel Read(long id) => _data.FirstOrDefault(x => x.Id == id);

        private void SeedSampleData()
        {
            var id = 0;

            _data = new Faker<PersonModel>()
                .RuleFor(x => x.Id, (f, u) => id++)
                .RuleFor(x => x.Firstname, (f, u) => f.Name.FirstName())
                .RuleFor(x => x.Lastname, (f, u) => f.Name.LastName())
                .Generate(500);
        }
    }
}