using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IUnitOfWork 
    {
        IProductRepository ProductRepository { get; }
        IOrderRepository OrderRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IBuyQueueRepository BuyQueueRepository { get; }
        ITransportQueueRepository TransportQueueRepository { get; }
        Task CommitAsync();
    }
}