using AppGreat.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppGreat.Data.Seeder
{
    public static class AppGreatSeeder
    {
        public static void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
               new Product
               {
                   Id = 1,
                   Name = "Rubberised Print T-Shirt",
                   Price = 9.99,
                   ImageURL = "https://st.depositphotos.com/2251265/4803/i/450/depositphotos_48037605-stock-photo-man-wearing-t-shirt.jpg"
               });

            modelBuilder.Entity<Product>().HasData(
               new Product
               {
                   Id = 2,
                   Name = "Contrast Top TRF",
                   Price = 11.99,
                   ImageURL = "https://picture-cdn.wheretoget.it/tvrznj-i.jpg"
               });

            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 3,
                Name = "Tied Leather Heeled Sandals",
                Price = 39.95,
                ImageURL = "https://cf.shopee.com.my/file/36df2e1d04ca103f16ccefffa9927728"
            });

            modelBuilder.Entity<Product>().HasData(
             new Product
             {
                 Id = 4,
                 Name = "Pleated Palazzo Trousers TRF",
                 Price = 29.95,
                 ImageURL = "https://cf.shopee.ph/file/fecc650ca5802d709890a66cc00cfe23"
             });

            modelBuilder.Entity<Product>().HasData(
              new Product
              {
                  Id = 5,
                  Name = "Skinny Trousers With Belt",
                  Price = 19.99,
                  ImageURL = "https://emma.bg/images/products/damski-pantalon-faded-black-super-skinny-trousers-1.jpg"
              });


        }
    }
}
