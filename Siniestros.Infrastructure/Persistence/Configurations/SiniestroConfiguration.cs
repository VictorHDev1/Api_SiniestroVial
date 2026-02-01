using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Siniestros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siniestros.Infrastructure.Persistence.Configurations
{
    public class SiniestroConfiguration : IEntityTypeConfiguration<Siniestro>
    {
        public void Configure(EntityTypeBuilder<Siniestro> builder)
        {
            builder.ToTable("Siniestros");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd(); 

            builder.HasMany(x => x.Vehiculos)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
