using System.Threading.Tasks;
using DAL.DataModels;

namespace BLL.Interfaces
{
    public interface ITransportQueueManager
    {
        Task CreatesTransportQueue(TransportQueueModel transportQueueModel);
        Task AddItemInTransportQueues (int id);
    }
}