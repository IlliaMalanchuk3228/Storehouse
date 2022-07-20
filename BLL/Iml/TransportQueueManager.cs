using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.DataModels;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Iml
{
    public class TransportQueueManager : ITransportQueueManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransportQueueManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<TransportQueueModel> GetTransportQueueById(int transportQueueId)
        {
            return await _unitOfWork.TransportQueueRepository.GetTransportQueueById(transportQueueId);
        }

        public async Task AddingToTransportQueue(int buyQueueId)
        {
            var buyQueueItem = await _unitOfWork.BuyQueueRepository.GetBuyQueueByIdAsync(buyQueueId);

            var transportQueue = new TransportQueueModel()
            {
                IsShipping = true,
                BuyQueueId = buyQueueItem.Id,
                ProductId = buyQueueItem.ProductId
            };
            await _unitOfWork.TransportQueueRepository.Create(transportQueue);
        }
        
    }
}
