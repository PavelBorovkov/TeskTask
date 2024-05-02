using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestTask.Persistance.EntityTypeConfigurations
{
    public class CoinConfiguration : IEntityTypeConfiguration<Coin>
    {
        public void Configure(EntityTypeBuilder<Coin> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Id).HasColumnType("integer").HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
            builder.Property(x => x.Value).HasColumnType("integer");
            builder.HasIndex(x => x.Value).IsUnique();
            builder.Property(x => x.Quantity).HasColumnType("integer");
            builder.Property(x => x.Access).HasColumnType("bool");
        }
    }
}
