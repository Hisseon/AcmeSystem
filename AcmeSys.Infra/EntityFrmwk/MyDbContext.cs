using AcmeSys.Dominio.Elements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace AcmeSys.Infra.EntityFrmwk
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Subsidiary> Subsidiaries { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Sale> Sales { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => p.ProductId);
            modelBuilder.Entity<Subsidiary>().HasKey(s => s.SubsidiaryId);
            modelBuilder.Entity<Inventory>().HasKey(i => i.InventoryId);
            modelBuilder.Entity<Purchase>().HasKey(p => p.PurchaseId);
            modelBuilder.Entity<Sale>().HasKey(s => s.SaleId);            
        }


    }


}
