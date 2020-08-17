using System;
using System.Collections.Generic;
using System.Text;
using AppGreat.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppGreat.Data.Configuration
{
    public class OrderProductsConfig : IEntityTypeConfiguration<OrderProducts>
    {
        public void Configure(EntityTypeBuilder<OrderProducts> builder)
        {
            builder.HasKey(op => new { op.ProductId, op.OrderId });
        }
    }
}
