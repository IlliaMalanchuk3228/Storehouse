using System.Threading.Tasks;
using BLL.Interfaces;
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
        [Route("nonAvailableAndToTransportQueue")]
        [HttpPost]
        public async Task OrderNonAvailableItemsAndToTransportQueue(int productId, int customerId)
        {
            await _orderManager.OrderNonAvailableItemAndAddingToTransportQueue(productId, customerId);
        }
        
        //POST
        [Route("nonAvailableAndToBuyQueue")]
        [HttpPost]
        public async Task OrderNonAvailableItemsAndToBuyQueue(int productId, int customerId)
        {
            await _orderManager.OrderNonAvailableItemAndAddingToBuyQueue(productId, customerId);
        }
        
        [Route("orderAvailableItem")]
        [HttpPost]
        public async Task OrderAvailableItems(int productId, int customerId)
        {
            await _orderManager.OrderAvailableItem(productId, customerId);
        }
        
        // [Route("orderNonAvailableItem")]
        // [HttpPost]
        // public async Task OrderProducts(List<int> productIds, int customerId)
        // { 
        //     await _orderManager.OrderProduct(productIds, customerId);
        // }
    }
}