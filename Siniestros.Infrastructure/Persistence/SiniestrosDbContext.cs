using Microsoft.EntityFrameworkCore;
using Siniestros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siniestros.Infrastructure.Persistence
{
    public class SiniestrosDbContext : DbContext
    {
        public SiniestrosDbContext(DbContextOptions<SiniestrosDbContext> options)
            : base(options) { }

        public DbSet<Siniestro> Siniestros => Set<Siniestro>();
        public DbSet<Vehiculo> Vehiculos => Set<Vehiculo>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SiniestrosDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
