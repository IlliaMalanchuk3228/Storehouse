using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.DataModels;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Iml
{
    public class CustomerManager : ICustomerManager
    {
        private readonly IUnitOfWork _unitOfWork;

        
        public CustomerManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerModel> GetCustomer(int customerId)
        {
            return await _unitOfWork.CustomerRepository.GetCustomerByIdAsync(customerId);
        }

        public async Task CreatesCustomer(CustomerModel customerModel)
        {
            await _unitOfWork.CustomerRepository.Create(customerModel);
        }

        // public async Task AddOrderToCustomer(int idCustomer, int orderId, Order orderr)
        // {
        //     var orders = await _unitOfWork.OrderRepository.GetOrderByIdAsync(orderId);
        //     var customer = await _unitOfWork.CustomerRepository.GetCustomerByIdAsync(idCustomer);
        //
        //     orderr = orders;
        //     
        //     customer.Orders = new List<Order>()
        //     {
        //         orderr
        //     };
        //     await _unitOfWork.CustomerRepository.UpdateAsync(customer);
        // }
        // public async Task JoinOrderAndCustomer(int orderId, int customerId)
        // {
        //     var orders = await _unitOfWork.OrderRepository.GetOrderByIdAsync(orderId);
        //     var customer = await _unitOfWork.CustomerRepository.GetCustomerByIdAsync(customerId);
        //
        //     customer.Orders = new List<Order>()
        //     {
        //         orders
        //     };
        //     await _unitOfWork.CustomerRepository.UpdateAsync(customer);
        // }
    }
}