namespace DAL.Entities
{
    public class TransportQueue : BaseEntity
    {
        public virtual bool IsShipping { get; set; }
        
        public virtual int BuyQueueId { get; set; }
        public virtual int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual BuyQueue BuyQueue { get; set; }
    }
} 