namespace DataModels
{
    public class TransportQueueModel
    {
        public virtual int TransportQueueId { get; set; }
        public virtual bool IsShipping { get; set; }
        public virtual int BuyQueueId { get; set; }
        public virtual int ProductId { get; set; }
    }
}