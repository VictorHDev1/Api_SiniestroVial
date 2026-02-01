using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siniestros.Application.Common;
using Siniestros.Application.DTOs;


namespace Siniestros.Application.Interfaces
{
    public interface ISiniestroReadRepository
    {
        Task<PagedResult<SiniestroDto>> GetAsync(
            string? departamento,
            DateTime? fechaInicio,
            DateTime? fechaFin,
            int page,
            int pageSize);
    }
}
