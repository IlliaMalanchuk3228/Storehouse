using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.DataModels;
using DAL.Entities;

namespace DAL.Repositories
{
    public interface ICustomerRepository : IRepository<CustomerModel>
    {
        Task Create(CustomerModel customerModel);
        Task<CustomerModel> GetCustomerByIdAsync(int id);
        // Task<List<Customer>> GetAllCustomersAsync();
    }
}
