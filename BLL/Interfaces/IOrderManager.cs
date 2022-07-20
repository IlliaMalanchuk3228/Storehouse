using System.Threading.Tasks;
using DAL.DataModels;

namespace BLL.Interfaces
{
    public interface IOrderManager
    {
        Task CreateOrderForAvailableItem(OrderModel orderModel, int productId, int customerId);
 
        Task OrderNonAvailableItemToBuyQueue(OrderModel orderModel, int productId, int customerId);

        Task OrderNonAvailableItemAndAddingToTransportQueue(OrderModel orderModel, int buyQueueId);
    }
}
