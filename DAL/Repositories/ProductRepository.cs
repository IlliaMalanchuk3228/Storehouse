using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DAL.DataContexts;
using DAL.DataModels;
using AutoMapper;
using DAL.Entities;

namespace DAL.Repositories
{
    public class ProductRepository : Repository<ProductModel>, IProductRepository
    {
        private readonly DataContext _dataContext;
        private static readonly IMapper MapperInstance = BuildMapper;
        public ProductRepository(DataContext dataContexts) : base(dataContexts)
        {
            _dataContext = dataContexts;
        }

        public async Task Create(ProductModel productModel)
        {
            var entity = MapperInstance.Map<Product>(productModel);
            _dataContext.Products.Add(entity);
            await _dataContext.SaveChangesAsync();
        }
        public async Task<ProductModel> GetProductByIdAsync(int id)
        {
            var entity = await _dataContext.Products.FirstOrDefaultAsync(product => product.Id == id);
            return MapperInstance.Map<ProductModel>(entity);
        }
        
        // public async Task<IEnumerable<ProductModel>> GetProductListByIdAsync(List<int> ids)
        // {
        //     // return await _dataContext.Products.Where(product => ids.Contains(product.Id)).ToListAsync();
        // }

        private static Mapper BuildMapper
        {
            get
            {
                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ProductModel, Product>();
                    cfg.CreateMap<Product, ProductModel>();
                });
                var mapperInstance = new Mapper(configuration);
                return mapperInstance;
            }
        }
    }
}