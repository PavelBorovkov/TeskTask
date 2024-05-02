using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain;

namespace TestTask.Persistance.EntityTypeConfigurations
{
    public class ProductConfiguration:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Quantity).HasColumnType("integer");
            builder.Property(x=>x.Price).HasColumnType("decimal(10,2)");
        }
    }
}
