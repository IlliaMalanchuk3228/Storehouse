using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.DataModels;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Iml
{
    public class OrderManager : IOrderManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBuyQueueManager _buyQueueManager;
        private readonly ITransportQueueManager _transportQueueManager;
 
        public OrderManager(IUnitOfWork unitOfWork, IBuyQueueManager buyQueueManager, ITransportQueueManager transportQueueManager)
        {
            _unitOfWork = unitOfWork;
            _buyQueueManager = buyQueueManager;
            _transportQueueManager = transportQueueManager;
        }
        
        public async Task CreateOrderForAvailableItem(OrderModel orderModel, int productId, int customerId)
        {
            var product = await _unitOfWork.ProductRepository.GetProductByIdAsync(productId);
            var customer = await _unitOfWork.CustomerRepository.GetCustomerByIdAsync(customerId);

            if (product.IsAvailable)
            {
                orderModel.ProductId = product.Id;
                orderModel.CustomerId = customer.Id;
                orderModel.IsDelivered = true;
                orderModel.IsSold = true;
            }
            await _unitOfWork.OrderRepository.Create(orderModel);
        }

        public async Task OrderNonAvailableItemToBuyQueue(OrderModel orderModel, int productId, int customerId)
        {
            var product = await _unitOfWork.ProductRepository.GetProductByIdAsync(productId);
            var customer = await _unitOfWork.CustomerRepository.GetCustomerByIdAsync(customerId);
            
            if (product.IsAvailable != true)
            {
                orderModel.ProductId = product.Id;
                orderModel.CustomerId = customer.Id;
                orderModel.IsDelivered = false;
                orderModel.IsSold = false;
            }

            await _unitOfWork.OrderRepository.Create(orderModel);
            await _buyQueueManager.AddingToBuyQueue(productId);
        }
        
        public async Task OrderNonAvailableItemAndAddingToTransportQueue(OrderModel orderModel, int  buyQueueId)
        {
            var buyQueue = await _buyQueueManager.GetBuyQueuesByIdAsync(buyQueueId); 
            var product = await _unitOfWork.ProductRepository.GetProductByIdAsync(buyQueue.ProductId);
            
            if (product.IsAvailable != true)
            {
                await _unitOfWork.OrderRepository.Update(orderModel);
                await _unitOfWork.CommitAsync();
                await _transportQueueManager.AddingToTransportQueue(buyQueueId);
            }
        }
        
    }
}
