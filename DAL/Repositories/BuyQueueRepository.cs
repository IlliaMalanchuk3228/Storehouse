using System.Threading.Tasks;
using AutoMapper;
using DAL.DataContexts;
using DAL.DataModels;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class BuyQueueRepository : Repository<BuyQueueModel>, IBuyQueueRepository
    {
        private readonly DataContext _dataContext;
        private static readonly IMapper MapperInstance = BuildMapper;
        public BuyQueueRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
        
        public async Task Create(BuyQueueModel buyQueueModel)
        {
            var entity = MapperInstance.Map<BuyQueue>(buyQueueModel);
            _dataContext.BuyQueues.Add(entity);
            await _dataContext.SaveChangesAsync();
        }
        
        public async Task<BuyQueueModel> GetBuyQueueByIdAsync(int id)
        {
            var entity = await _dataContext.BuyQueues.FirstOrDefaultAsync(buyQueue => buyQueue.Id == id);
            return MapperInstance.Map<BuyQueueModel>(entity);
        }
        
        private static Mapper BuildMapper
        {
            get
            {
                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<BuyQueueModel, BuyQueue>();
                    cfg.CreateMap<BuyQueue, BuyQueueModel>();
                });

                var mapperInstance = new Mapper(configuration);
                return mapperInstance;
            }
        }
    }
}