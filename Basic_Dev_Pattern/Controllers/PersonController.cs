using Microsoft.AspNetCore.Mvc;
using Basic_Dev_Pattern.Services;
using Microsoft.Extensions.Configuration;

namespace Basic_Dev_Pattern.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController(IPhoneBook phoneBook, IConfiguration configuration) : ControllerBase
    {
        private readonly IPhoneBook _phoneBook = phoneBook;
        private readonly IConfiguration _configuration = configuration;

        [Route("getpersons")]
        [HttpGet]
        public IActionResult GetPersons()
        {
            var persons = _phoneBook.GetPersons();


            // var getApsettingsVal = _configuration.GetValue<int>("AppSettings:PrivateSetings:MyKey2");

            //var getApsettingsVal = _configuration.GetValue<bool>("AppSettings:BoolKey");


            var getAppSettings = _configuration.GetSection("AppSettings");

            string myKey1 = getAppSettings["MyKey1"]!;
            string dbConnection = getAppSettings["DbConnection"]!;
            bool boolKey = bool.Parse(getAppSettings["BoolKey"]!);

            // To access values within nested objects, chain the keys with :
            int myKey2 = int.Parse(getAppSettings["PrivateSetings:MyKey2"]!);

            // Access Array []
            var personsSection = getAppSettings.GetSection("Persons");
            

            // loop through collection
            foreach (var person in personsSection.GetChildren())
            {
                Console.WriteLine(person.Value);
            }


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
