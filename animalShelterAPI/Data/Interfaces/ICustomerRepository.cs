using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalAPI.Data
{

    public interface ICustomerRepository 
    {
        Task<List<CustomerDTO>> GetAllCustomers();
        Task<CustomerDTO> GetCustomerById(int id);
    }
}