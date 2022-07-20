using System.Threading.Tasks;
using DAL.DataModels;

namespace BLL.Interfaces
{
    public interface IBuyQueueManager
    {
        Task CreateBuyQueue(BuyQueueModel buyQueueModel);
        Task<BuyQueueModel> GetBuyQueuesByIdAsync(int buyQueueId);
        Task AddingToBuyQueue(int productId); 
    }
}
