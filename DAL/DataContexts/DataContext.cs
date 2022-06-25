using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataContexts
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BuyQueue> BuyQueues { get; set; }
        public DbSet<TransportQueue> TransportQueues { get; set; }
        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

    }
}