using System;
using System.Collections.Generic;
using System.Text;
using AppGreat.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppGreat.Data.Configuration
{
    //User table configuration
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Username).IsRequired();
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.CurrencyCode).IsRequired();
        }
    }
}
