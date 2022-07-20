using System.Threading.Tasks;
using AutoMapper;
using DAL.DataContexts;
using DAL.DataModels;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{ 
    public class OrderRepository : Repository<OrderModel>, IOrderRepository
    {
        private readonly DataContext _dataContext;
        private static readonly IMapper MapperInstance = BuildMapper;
        public OrderRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Create(OrderModel orderModel)
        {
            var entity = MapperInstance.Map<Order>(orderModel);
            _dataContext.Orders.Add(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Update(OrderModel orderModel)
        {
            var entity = MapperInstance.Map<Order>(orderModel);
            _dataContext.Orders.Update(entity);
            await _dataContext.SaveChangesAsync();
        }
        
        public async Task<OrderModel> GetOrderByIdAsync(int id)
        {
            var entity = await _dataContext.Orders.FirstOrDefaultAsync(order => order.Id == id);
            return MapperInstance.Map<OrderModel>(entity);
        }

        private static Mapper BuildMapper
        {
            get
            {
                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<OrderModel, Order>();
                    cfg.CreateMap<Order, OrderModel>();
                });
                var mapperInstance = new Mapper(configuration);
                return mapperInstance;
            }
        }
    }
}
