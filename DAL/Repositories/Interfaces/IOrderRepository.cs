using System.Threading.Tasks;
using DAL.DataModels;
using DAL.Entities;

namespace DAL.Repositories
{
    public interface IOrderRepository : IRepository<OrderModel>
    {
        Task Create(OrderModel orderModel);
        Task<OrderModel> GetOrderByIdAsync(int id);
        
    }
}