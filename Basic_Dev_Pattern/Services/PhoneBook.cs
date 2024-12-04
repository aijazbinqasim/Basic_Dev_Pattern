using Basic_Dev_Pattern.Models;
using Microsoft.Extensions.Logging;

namespace Basic_Dev_Pattern.Services
{
    public class PhoneBook(IConfiguration configuration, ILogger<PhoneBook> logger) : IPhoneBook
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly ILogger<PhoneBook> _logger = logger;

        public PersonModel GetPerson(int id)
        {
            var person = new List<PersonModel>()
            {
                 new() { Id = 1, Name = "Aijaz", Age = 30 },
                 new() { Id = 2, Name = "Walidad", Age = 22 },
                 new() { Id = 3, Name = "Ghani", Age = 35 },
                 new() { Id = 4, Name = "Khan", Age = 40 }

            }.FirstOrDefault(p => p.Id == id)!;

            return person;
        }

        public IEnumerable<PersonModel> GetPersons()
        {
            //var getApsettingsVal = _configuration["AppSettings:DbConnection"];

            var getApsettingsVal = _configuration.GetValue<string>("AppSettings:MyKey1");

            _logger.LogInformation(message: getApsettingsVal);

            var persons = new List<PersonModel>()
            {
                 new() { Id = 1, Name = "Aijaz", Age = 30 },
                 new() { Id = 2, Name = "Walidad", Age = 22 },
                 new() { Id = 3, Name = "Ghani", Age = 35 },
                 new() { Id = 4, Name = "Khan", Age = 40 }
            };

            return persons;
        }

        public void IdontKnow()
        {
            throw new NotImplementedException();
        }
    }
}
