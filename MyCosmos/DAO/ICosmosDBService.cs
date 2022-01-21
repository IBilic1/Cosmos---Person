using MyCosmos.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCosmos.DAO
{
    public interface ICosmosDBService
    {
        Task<IEnumerable<Person>> GetPeopleAsync(string queryString);
        Task<Person> GetPersonAsync(string id);
        Task InsertPersonAsync(Person person);
        Task UpdatePersonAsync(Person person);
        Task DeletePersonAsync(Person person);
    }
}
