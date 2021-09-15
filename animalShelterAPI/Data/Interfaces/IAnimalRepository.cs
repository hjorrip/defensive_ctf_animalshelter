using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalAPI.Data
{

    public interface IAnimalRepository 
    {
        Task<List<AnimalDTO>> GetAllAnimalsAsync(string domainName);
    }
}