using ApiSimpleApp.Commons;
using ApiSimpleApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSimpleApp.Core.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        List<Person> GetPersonsListAll();
        BaseResponse SavePerson(Person person);
        BaseResponse DeletePerson(int IdPerson);
    }
}
