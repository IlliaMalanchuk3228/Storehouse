namespace DataModels
{
    public class BuyQueueModel
    {
        public virtual int BuyQueueId { get; set; }
        public virtual bool IsBuying { get; set; }
        public virtual int ProductId { get; set; }
    }
}