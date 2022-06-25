using System.Threading.Tasks;
using DAL.DataContexts;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        private IProductRepository _productRepository;
        private IOrderRepository _orderRepository;
        private ICustomerRepository _customerRepository;
        private IBuyQueueRepository _buyQueueRepository;
        private ITransportQueueRepository _transportQueueRepository;
        
        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return _productRepository = _productRepository ?? new ProductRepository(_dataContext);
            }
        }

        public IOrderRepository OrderRepository
        {
            get
            {
                return _orderRepository = _orderRepository ?? new OrderRepository(_dataContext);
            }
        }

        public ICustomerRepository CustomerRepository
        {
            get
            {
                return _customerRepository = _customerRepository ?? new CustomerRepository(_dataContext);
            }
        }

        public IBuyQueueRepository BuyQueueRepository
        {
            get
            {
                return _buyQueueRepository = _buyQueueRepository ?? new BuyQueueRepository(_dataContext);
            }
        }

        public ITransportQueueRepository TransportQueueRepository
        {
            get
            {
                return _transportQueueRepository = _transportQueueRepository ?? new TransportQueueRepository(_dataContext);
            }
        }
        
        public async Task CommitAsync()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}