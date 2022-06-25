namespace DAL.Entities
{
    public class BuyQueue : BaseEntity
    {
        public virtual bool IsBuying { get; set; }
        public virtual int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual TransportQueue TransportQueue { get; set; }
    }
}