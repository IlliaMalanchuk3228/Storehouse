using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DAL.DataContexts;
using DAL.DataModels;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class CustomerRepository : Repository<CustomerModel>, ICustomerRepository
    {
        private readonly DataContext _dataContext;
        private static readonly IMapper MapperInstance = BuildMapper;
        public CustomerRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
        
        public async Task Create(CustomerModel customerModel)
        {
            var entity = MapperInstance.Map<Customer>(customerModel);
            _dataContext.Customers.Add(entity);
            await _dataContext.SaveChangesAsync();
        }
        
        public async Task<CustomerModel> GetCustomerByIdAsync(int id)
        {
            var entity = await _dataContext.Customers.FirstOrDefaultAsync(customer => customer.Id == id);
            return MapperInstance.Map<CustomerModel>(entity);
        }

        private static Mapper BuildMapper
        {
            get
            {
                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CustomerModel, Customer>();
                    cfg.CreateMap<Customer, CustomerModel>();
                });
                var mapperInstance = new Mapper(configuration);
                return mapperInstance;
            }
        }
        
        
    }
}