using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using DAL.DataModels;
 
namespace Storehouse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuyQueueController : Controller
    {
        private readonly IBuyQueueManager _buyQueueManager;

        public BuyQueueController(IBuyQueueManager manager)
        {
            _buyQueueManager = manager;
        }
        
        //POST
        [Route("createBuyQueue")]
        [HttpPost]
        public async Task CreateBuyQueues(BuyQueueModel buyQueueModel)
        {
            await _buyQueueManager.CreateBuyQueue(buyQueueModel);
        }
        
        //GET
        [Route("getBuyQueue")]
        [HttpGet]
        public async Task<BuyQueueModel> GetBuyQueues(int buyQueueId)
        {
           return await _buyQueueManager.GetBuyQueuesByIdAsync(buyQueueId);
        }
        
        //POST
        [Route("updateBuyQueue")]
        [HttpPut]
        public async Task UpdateBuyQueues(int productId)
        {
            await _buyQueueManager.AddingToBuyQueue(productId);
        }
        
    }
}

