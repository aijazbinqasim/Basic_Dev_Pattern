using Basic_Dev_Pattern.Models;

namespace Basic_Dev_Pattern.Services
{
    public interface IPhoneBook
    {
        IEnumerable<PersonModel> GetPersons();
        PersonModel GetPerson(int id);
        void IdontKnow();
    }
}
