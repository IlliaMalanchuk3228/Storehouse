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
        [Route("oleni")]
        [HttpPost]
        public async Task CreateBuyQueues(BuyQueueModel buyQueueModel)
        {
            await _buyQueueManager.CreatesBuyQueue(buyQueueModel);
        }
        
        //POST
        [Route("pogus")]
        [HttpPost]
        public async Task AddItemInBuyQueue(int idProduct)
        {
            await _buyQueueManager.AddItemInBuyQueues(idProduct);
        }
        
    }
}

