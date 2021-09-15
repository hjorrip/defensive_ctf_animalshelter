using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnimalAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalAPI.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerRepository _repository;
        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;

        }


        [HttpGet]
        public async Task<ActionResult<List<CustomerDTO>>> GetAllCustomers()
        {
            try
            {
                List<CustomerDTO> customers = await _repository.GetAllCustomers();

                return Ok(customers);
            } 
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<CustomerDTO>> GetCustomerById(int id)
        {
            try
            {
                CustomerDTO customer = await _repository.GetCustomerById(id);

                if(customer is null)
                {
                    return NotFound();
                } 
                else 
                {
                    return Ok(customer);
                }

            } 
            catch (Exception)
            {
                return StatusCode(500);
            }
        }


  
    }
}
