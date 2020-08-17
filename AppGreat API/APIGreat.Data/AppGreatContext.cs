using System;
using AppGreat.Data.Configuration;
using AppGreat.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIGreat.Data
{
    public class AppGreatContext : DbContext
    {
        public AppGreatContext(DbContextOptions<AppGreatContext> options) 
            : base(options)
        {

        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<OrderProducts> OrderProducts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new OrderProductsConfig());

            AppGreat.Data.Seeder.AppGreatSeeder.SeedDatabase(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
