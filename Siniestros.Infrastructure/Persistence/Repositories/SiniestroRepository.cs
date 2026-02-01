using Siniestros.Application.Interfaces;
using Siniestros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siniestros.Infrastructure.Persistence.Repositories
{
    public class SiniestroRepository : ISiniestroRepository
    {
        private readonly SiniestrosDbContext _context;

        public SiniestroRepository(SiniestrosDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Siniestro siniestro)
        {
            _context.Siniestros.Add(siniestro);
            await _context.SaveChangesAsync();
        }
    }
}
