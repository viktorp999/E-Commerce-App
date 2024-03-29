﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkinetCore.Entities;

namespace SkinetInfrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.PictureUrl).IsRequired();
            builder.HasOne(b => b.ProductBrand).WithMany()
                .HasForeignKey(fk => fk.ProductBrandId);
            builder.HasOne(b => b.ProductType).WithMany()
                .HasForeignKey(fk => fk.ProductTypeId);
        }
    }
}
