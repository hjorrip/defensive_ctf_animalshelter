using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AnimalAPI.Data
{
    public class AnimalRepository : IAnimalRepository
    {

        private readonly ShelterDbContext _dbContext;

        public AnimalRepository(ShelterDbContext context)
        {
            _dbContext = context;
        
        }

        public async Task<List<AnimalDTO>> GetAllAnimalsAsync(string domainName)
        {
            using var db = _dbContext;
            List<Animal> animals = await db.Animals.ToListAsync();

            List<AnimalDTO> animalDTOs = new();

            foreach(Animal animal in animals){
                AnimalDTO dto = new(animal.Name, animal.Species, $"http://{domainName}/{animal.IMGUrl}", animal.Description);

                animalDTOs.Add(dto);
            }

            return animalDTOs;
        }
    }
}