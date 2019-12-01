using ApiSimpleApp.Commons;
using ApiSimpleApp.Core.Models;
using ApiSimpleApp.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSimpleApp.Core.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IConnectionRepository _connectionRepository;

        public PersonRepository(IConnectionRepository connectionRepository)
        {
            _connectionRepository = connectionRepository;
        }

        public BaseResponse DeletePerson(int IdPerson)
        {
            try
            {
                var parameters = new Dictionary<string, object>()
                {
                    { "IdPerson", IdPerson }
                };

                return _connectionRepository.ExecuteQueryProcedureToXml<BaseResponse>("[dbo].[usp_Person_Delete]", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Person> GetPersonsListAll()
        {
            try
            {
                return _connectionRepository.ExecuteQueryProcedureToXmlList<Person>("[dbo].[usp_Person_ListAll]");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public BaseResponse SavePerson(Person person)
        {
            try
            {
                var parameters = new Dictionary<string, object>()
                {
                    { "IdPerson", person.IdPerson },
                    { "Firstname", person.Firstname },
                    { "Lastname", person.Lastname }
                };

                return _connectionRepository.ExecuteQueryProcedureToXml<BaseResponse>("[dbo].[usp_Person_Save]", parameters);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
