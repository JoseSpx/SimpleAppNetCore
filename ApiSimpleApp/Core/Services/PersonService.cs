using ApiSimpleApp.Commons;
using ApiSimpleApp.Core.Models;
using ApiSimpleApp.Core.Repositories.Interfaces;
using ApiSimpleApp.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSimpleApp.Core.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public BaseResponse DeletePerson(int IdPerson)
        {
            return _personRepository.DeletePerson(IdPerson);
        }

        public List<Person> GetPersonsListAll()
        {
            return _personRepository.GetPersonsListAll();
        }

        public BaseResponse SavePerson(Person person)
        {
            return _personRepository.SavePerson(person);
        }
    }
}
