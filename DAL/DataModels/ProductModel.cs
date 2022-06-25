namespace DAL.DataModels
{
    public class ProductModel
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Category { get; set; }
        public virtual bool IsAvailable { get; set; }
    }
}