using MediatR;
using Siniestros.Application.Common;
using Siniestros.Application.DTOs;
using Siniestros.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siniestros.Application.Queries.ConsultarSiniestros
{
    public class ConsultarSiniestrosHandler
        : IRequestHandler<ConsultarSiniestrosQuery, PagedResult<SiniestroDto>>
    {
        private readonly ISiniestroReadRepository _repository;

        public ConsultarSiniestrosHandler(ISiniestroReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<SiniestroDto>> Handle(
            ConsultarSiniestrosQuery request,
            CancellationToken cancellationToken)
        {
            return await _repository.GetAsync(
                request.Departamento,
                request.FechaInicio,
                request.FechaFin,
                request.Page,
                request.PageSize);
        }
    }
}
