using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.DataModels;
using Microsoft.AspNetCore.Mvc;
 
namespace Storehouse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransportQueueController : Controller
    {
        private readonly ITransportQueueManager _transportQueueManager;

        public TransportQueueController(ITransportQueueManager transportQueueManager)
        {
            _transportQueueManager = transportQueueManager;
        }
        
        //GET
        [Route("getTransportQueue")]
        [HttpGet]
        public async Task<TransportQueueModel> GetTransportQueues(int transportQueueId)
        {
            return await _transportQueueManager.GetTransportQueueById(transportQueueId);
        }
        
        //POST
        [Route("createTransportQueue")]
        [HttpPost]
        public async Task CreatesTransportQueue(int buyQueueId)
        {
            await _transportQueueManager.AddingToTransportQueue(buyQueueId);
        }
        
    }
}
