using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.DataModels;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Storehouse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerManager _customerManager;

        public CustomerController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }
        
        [Route("addCustomer")]
        [HttpPost]
        public async Task CreateCustomers(CustomerModel customerModel)
        {
            await _customerManager.CreatesCustomer(customerModel);
        }
        
        // [Route("joinOrderAndCustomer")]
        // [HttpPatch]
        // public async Task UpdateOrdersInCustomer(int orderId, int customerId)
        // {
        //     await _customerManager.JoinOrderAndCustomer(orderId, customerId);
        // }
        
        [Route("getCustomer")]
        [HttpGet]
        public async Task<CustomerModel> GetCustomer(int customerId)
        {
            return await _customerManager.GetCustomer(customerId);
        }

    }
}