using System.Collections.Generic;

namespace DAL.Entities
{
    public class Product : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string Category { get; set; }
        public virtual bool IsAvailable { get; set; }
        public virtual BuyQueue BuyQueue { get; set; }
        public virtual TransportQueue TransportQueue { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }
    }
}