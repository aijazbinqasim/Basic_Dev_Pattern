using Microsoft.AspNetCore.Mvc;
using Basic_Dev_Pattern.Services;

namespace Basic_Dev_Pattern.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController(IPhoneBook phoneBook) : ControllerBase
    {
        private readonly IPhoneBook _phoneBook = phoneBook;

        [Route("getpersons")]
        [HttpGet]
        public IActionResult GetPersons()
        {
            var persons = _phoneBook.GetPersons();

            return Ok(persons);
        }


        [Route("getperson/{id}")]
        [HttpGet]
        public IActionResult GetPerson([FromRoute] int id)
        {
            var person = _phoneBook.GetPerson(id);
            if (person == null)
            {
                return NotFound(new { message = "Person Not Found!" });
            }

            return Ok(person);
        }
    }
}
