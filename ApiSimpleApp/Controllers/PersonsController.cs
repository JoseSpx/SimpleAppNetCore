using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSimpleApp.Commons;
using ApiSimpleApp.Core.Models;
using ApiSimpleApp.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSimpleApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IActionResult GetPersonsListAll()
        {
            try
            {
                var list = _personService.GetPersonsListAll();
                return Ok(list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public IActionResult SavePerson([FromBody] Person person)
        {
            try
            {
                BaseResponse response = _personService.SavePerson(person);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{IdPerson:int}")]
        public IActionResult DeletePerson([FromRoute] int IdPerson)
        {
            try
            {
                BaseResponse response = _personService.DeletePerson(IdPerson);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}