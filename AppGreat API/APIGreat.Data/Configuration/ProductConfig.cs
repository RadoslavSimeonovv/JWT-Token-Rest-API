using System;
using System.Collections.Generic;
using System.Text;
using AppGreat.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AppGreat.Data.Configuration
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired();
            builder.HasIndex(p => p.Name).IsUnique();
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.ImageURL).IsRequired();
        }
    }
}
