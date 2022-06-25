using System.Threading.Tasks;
using AutoMapper;
using DAL.DataContexts;
using DAL.DataModels;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class TransportQueueRepository : Repository<TransportQueueModel>, ITransportQueueRepository
    {
        private readonly DataContext _dataContext;
        private static readonly IMapper MapperInstance = BuildMapper;
        public TransportQueueRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
        
        public async Task Create(TransportQueueModel transportQueueModel)
        {
            var entity = MapperInstance.Map<TransportQueue>(transportQueueModel);
            _dataContext.TransportQueues.Add(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<TransportQueueModel> GetTransportQueueById(int id)
        {
            var entity = await _dataContext.TransportQueues.FirstOrDefaultAsync(trQueue => trQueue.Id == id);
            return MapperInstance.Map<TransportQueueModel>(entity);
        }

        private static Mapper BuildMapper
        {
            get
            {
                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<TransportQueueModel, TransportQueue>();
                    cfg.CreateMap<TransportQueue, TransportQueueModel>();
                });
                var mapperInstance = new Mapper(configuration);
                return mapperInstance;
            }
        }
    }
}