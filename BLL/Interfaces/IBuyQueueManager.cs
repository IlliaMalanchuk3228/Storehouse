using System.Threading.Tasks;
using DAL.DataModels;

namespace BLL.Interfaces
{
    public interface IBuyQueueManager
    {
        Task CreatesBuyQueue(BuyQueueModel buyQueueModel);
        Task AddItemInBuyQueues (int id);
    }
}