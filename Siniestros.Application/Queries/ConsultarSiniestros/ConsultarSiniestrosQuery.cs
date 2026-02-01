using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Siniestros.Application.Common;
using Siniestros.Application.DTOs;

namespace Siniestros.Application.Queries.ConsultarSiniestros
{
    public record ConsultarSiniestrosQuery(
      string? Departamento,
      DateTime? FechaInicio,
      DateTime? FechaFin,
      int Page,
      int PageSize
  ) : IRequest<PagedResult<SiniestroDto>>;
}
