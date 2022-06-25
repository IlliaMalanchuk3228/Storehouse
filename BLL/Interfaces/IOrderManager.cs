using System.Threading.Tasks;
using DAL.DataModels;

namespace BLL.Interfaces
{
    public interface IOrderManager
    {
        Task CreatesOrder(OrderModel orderModel);
        Task OrderAvailableItem(int productId, int customerId);
        Task OrderNonAvailableItemAndAddingToBuyQueue(int productId, int customerId);
        Task OrderNonAvailableItemAndAddingToTransportQueue(int productId, int customerId);
        // Task OrderProduct(List<int> ids, int customerId);
    }
}