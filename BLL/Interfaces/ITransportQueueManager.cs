using System.Threading.Tasks;
using DAL.DataModels;

namespace BLL.Interfaces
{
    public interface ITransportQueueManager
    { 
        Task<TransportQueueModel> GetTransportQueueById(int transportQueueId);
        Task AddingToTransportQueue(int buyQueueId);
    }
}
