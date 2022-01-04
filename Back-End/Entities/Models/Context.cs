using Microsoft.EntityFrameworkCore;

namespace Entities.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        /*Configuracion de las relaciones que no se pueden
         * configurar con DataAnnotations*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrdersFoods>()
            .HasKey(s => new { s.FK_FoodID, s.FK_OrderID });

            modelBuilder.Entity<TablesWaiters>()
            .HasKey(s => new { s.FK_TableID, s.FK_WaiterID });

            modelBuilder.Entity<TablesOrders>()
            .HasKey(s => new { s.FK_TableID, s.FK_OrderID });

        }

        public DbSet<Foods> Foods { get; set; }
        public DbSet<Waiters> Waiters { get; set; }
        public DbSet<Tables> Tables { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<TablesOrders> TablesOrders { get; set; }
        public DbSet<TablesWaiters> TablesWaiters { get; set; }
        public DbSet<OrdersFoods> OrdersFoods { get; set; }

    }
}

