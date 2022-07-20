using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.DataModels;
using Microsoft.AspNetCore.Mvc;
 
namespace Storehouse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderManager _orderManager;

        public OrderController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }
        
        //POST
        [Route("nonAvailableItemAndToBuyQueue")]
        [HttpPost]
        public async Task OrderNonAvailableItemsAndToBuyQueue(OrderModel orderModel, int productId, int customerId)
        {
            await _orderManager.OrderNonAvailableItemToBuyQueue(orderModel, productId, customerId);
        }
        
        //POST
        [Route("nonAvailableItemAndToTransportQueue")]
        [HttpPut]
        public async Task OrderNonAvailableItemsAndToTransportQueue(OrderModel orderModel, int buyQueueId)
        {
            await _orderManager.OrderNonAvailableItemAndAddingToTransportQueue(orderModel,buyQueueId);
        }
        
        [Route("orderAvailableItem")]
        [HttpPost]
        public async Task OrderAvailableItems(OrderModel orderModel, int productId, int customerId)
        {
            await _orderManager.CreateOrderForAvailableItem(orderModel, productId, customerId);
        }
        
    }
}
