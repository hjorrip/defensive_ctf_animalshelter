using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AnimalAPI.Data
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly ShelterDbContext _dbContext;

        public CustomerRepository(ShelterDbContext context)
        {
            _dbContext = context;
        
        }


        public async Task<List<CustomerDTO>> GetAllCustomers()
        {
            using var db = _dbContext;
            List<Customer> customers = await db.Customers.ToListAsync(); 

            List<CustomerDTO> customerDTOs = new();

            foreach(Customer customer in customers){
                CustomerDTO dto = new(customer.FirstName, customer.LastName, customer.PhoneNr, customer.Email);

                customerDTOs.Add(dto);
            }

            return customerDTOs;
        }

        public async Task<CustomerDTO> GetCustomerById(int id)
        {
            using var db = _dbContext;
            Customer customer = await db.Customers.Where(x => x.Id == id).FirstOrDefaultAsync(); 

            CustomerDTO dto = new(customer.FirstName, customer.LastName, customer.Email, customer.PhoneNr);

            return dto;
        }



    }
}