using System.Threading.Tasks;
using DAL.DataModels;
using DAL.Entities;

namespace BLL.Interfaces
{
    public interface ICustomerManager
    {
        Task CreatesCustomer(CustomerModel customerModel);
        Task<CustomerModel> GetCustomer(int customerId);
        // Task JoinOrderAndCustomer(int orderId, int customerId);
        // Task AddOrderToCustomer(int idCustomer, int orderId, Order orderr);

    }
}