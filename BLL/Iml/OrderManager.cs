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

        public async Task CreatesOrder(OrderModel orderModel)
        {
            await _unitOfWork.OrderRepository.Create(orderModel);
        }

        public async Task OrderAvailableItem(int productId, int customerId)
        {
            var product = await _unitOfWork.ProductRepository.GetProductByIdAsync(productId);
            var customer = await _unitOfWork.CustomerRepository.GetCustomerByIdAsync(customerId);
            // var falseProduct = _unitOfWork.ProductRepository.GetAll().Where(p => p.IsAvailable == false);
            //TODO: Сделать проверку на вхождение товара не в наличии.
            
            var orders = new OrderModel()
            {
                Customers = customer,
                Products = new List<ProductModel>()
                {
                    product,
                },
                IsDelivered = true,
                IsSold = false,
            };
            await _unitOfWork.OrderRepository.AddAsync(orders);
        }
        
        public async Task OrderNonAvailableItemAndAddingToTransportQueue(int productId, int customerId)
        {
            // добавляем продукт в заказ + на достовку ?
            var product = await _unitOfWork.ProductRepository.GetProductByIdAsync(productId);
            var customers = await _unitOfWork.CustomerRepository.GetCustomerByIdAsync(customerId);
            
            var order = new OrderModel()
            {
                IsDelivered = true,
                IsSold = true,
                Products = new List<ProductModel>()
                {
                    product,
                },
                Customers = customers
            };
            
            // if (customers != null)
            // {
            //     order.Customer = customers;
            // }
            //
            await _unitOfWork.OrderRepository.AddAsync(order);
            await _transportQueueManager.AddItemInTransportQueues(productId);
        }

        public async Task OrderNonAvailableItemAndAddingToBuyQueue(int productId, int customerId)
        {
           // добавление продукта в заказ + добавление продукта в очередь на покупку
           var product = await  _unitOfWork.ProductRepository.GetProductByIdAsync(productId);
           var customers = await _unitOfWork.CustomerRepository.GetCustomerByIdAsync(customerId);
           
           var order = new OrderModel()
           {
               IsDelivered = false,
               IsSold = false,
               Products = new List<ProductModel>(productId)
               {
                   product
               },
           };
           if (customers != null)
           {
               order.Customers = customers;
           }
           await _buyQueueManager.AddItemInBuyQueues(productId);
           
        }

        
        // public async Task OrderProduct(List<int> ids, int customerId)
        // {
        //     var product = await _unitOfWork.ProductRepository.GetProductListByIdAsync(ids); 
        //     
        //     // product.Where(p=>p.IsAvailable==true).ToList().ForEach(async p =>
        //     // {
        //     //     await OrderAvailableItem(p.Id, customerId);
        //     // });
        //     // await OrderNonAvailableItemAndAddingToTransportQueue(p.Id, customerId);
        //     //
        //     product.Where(p=>p.IsAvailable != true).ToList().ForEach(async p =>
        //     {
        //         await OrderNonAvailableItemAndAddingToBuyQueue(p.Id, customerId);
        //     });
        //     product.Where(p=>p.IsAvailable != true).ToList().ForEach(async p =>
        //     {
        //         await OrderNonAvailableItemAndAddingToTransportQueue(p.Id, customerId);
        //     });
        // }
    }
}