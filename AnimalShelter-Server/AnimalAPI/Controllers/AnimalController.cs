using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalAPI.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AnimalAPI.Controllers
{
    [ApiController]
    [Route("api/animals")]
    public class AnimalController : ControllerBase
    {

        private readonly IAnimalRepository _repository;
        public AnimalController(IAnimalRepository repository)
        {
            _repository = repository;

        }


 
        [HttpGet]
        public async Task<ActionResult<List<AnimalDTO>>> GetAllAnimals()
        {
            try
            {
                string domainName = HttpContext.Request.Host.Value;

                List<AnimalDTO> animals = await _repository.GetAllAnimalsAsync(domainName);

                return Ok(animals);
            } 
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

  
    }
}
