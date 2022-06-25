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
        
        //POST
        [Route("createTrQueue")]
        [HttpPost]
        public async Task CreatesTransportQueue(TransportQueueModel transportQueueModel)
        {
            await _transportQueueManager.CreatesTransportQueue(transportQueueModel);
        }
    
        //POST
        [Route("addInTrQueue")]
        [HttpPost]
        public async Task AddItemInTransportQueue(int idItem)
        {
            await _transportQueueManager.AddItemInTransportQueues(idItem);
        }
        
    }
}