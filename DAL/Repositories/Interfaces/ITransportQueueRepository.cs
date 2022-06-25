using System.Threading.Tasks;
using DAL.DataModels;
using DAL.Entities;

namespace DAL.Repositories
{
    public interface ITransportQueueRepository : IRepository<TransportQueueModel>
    {
        Task Create(TransportQueueModel transportQueueModel);
        Task<TransportQueueModel> GetTransportQueueById(int id);
    }
}