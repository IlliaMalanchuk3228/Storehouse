using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using DAL.DataModels;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Iml
{
    public class BuyQueueManager : IBuyQueueManager
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public BuyQueueManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreatesBuyQueue(BuyQueueModel buyQueueModel)
        {
            await _unitOfWork.BuyQueueRepository.Create(buyQueueModel);
        }
        
        public async Task AddItemInBuyQueues(int id)
        {
            var pr =  await _unitOfWork.ProductRepository.GetProductByIdAsync(id);
            pr.IsAvailable = false;
            await _unitOfWork.CommitAsync();
           
            var itemQueues = new BuyQueueModel()
            {
                IsBuying = true,
                ProductModels = new List<ProductModel>()
                {
                    pr
                },
            };
            await _unitOfWork.BuyQueueRepository.AddAsync(itemQueues);
        }
    }
}   