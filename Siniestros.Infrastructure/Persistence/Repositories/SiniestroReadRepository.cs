using Microsoft.EntityFrameworkCore;
using Siniestros.Application.Common;
using Siniestros.Application.DTOs;
using Siniestros.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siniestros.Infrastructure.Persistence.Repositories
{
    public class SiniestroReadRepository : ISiniestroReadRepository
    {
        private readonly SiniestrosDbContext _context;

        public SiniestroReadRepository(SiniestrosDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<SiniestroDto>> GetAsync(
            string departamento,
            DateTime? fechaInicio,
            DateTime? fechaFin,
            int page,
            int pageSize)
        {
            var query = _context.Siniestros.AsQueryable();

            if (!string.IsNullOrEmpty(departamento))
                query = query.Where(x => x.Departamento == departamento);

            if (fechaInicio.HasValue)
                query = query.Where(x => x.FechaHora >= fechaInicio.Value);

            if (fechaFin.HasValue)
                query = query.Where(x => x.FechaHora <= fechaFin.Value);

            var total = await query.CountAsync();

            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new SiniestroDto
                {
                    Id = x.Id,
                    Departamento = x.Departamento,
                    Ciudad = x.Ciudad,
                    FechaHora = x.FechaHora,
                    Tipo = x.Tipo,
                    NumeroVictimas = x.NumeroVictimas
                })
                .ToListAsync();

            return new PagedResult<SiniestroDto>(items, total, page, pageSize);
        }
    }

    //Task<PagedResult<SiniestroDto>> ISiniestroReadRepository.GetAsync(string? departamento, DateTime? fechaInicio, DateTime? fechaFin, int page, int pageSize)
    //{
    //    throw new NotImplementedException();
    //}
}

