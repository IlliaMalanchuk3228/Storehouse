namespace DataModels
{
    public class CustomerModel
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual int Telephone { get; set; }
        public virtual IEnumerable<OrderModel> Order { get; set; }
    }
}
