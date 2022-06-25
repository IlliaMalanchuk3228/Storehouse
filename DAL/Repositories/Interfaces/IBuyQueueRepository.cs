using System.Threading.Tasks;
using DAL.DataModels;
using DAL.Entities;

namespace DAL.Repositories
{
    public interface IBuyQueueRepository : IRepository<BuyQueueModel>
    {
        Task Create(BuyQueueModel buyQueueModel);
        Task<BuyQueueModel> GetBuyQueueByIdAsync(int id);
    }
}