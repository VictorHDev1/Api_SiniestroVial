using MediatR;
using Siniestros.Application.DTOs;
using Siniestros.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Siniestros.Application.Commands.RegistrarSiniestro
{
    public record RegistrarSiniestroCommand(
     DateTime FechaHora,
     string Departamento,
     string Ciudad,
     TipoSiniestro Tipo,
     int NumeroVictimas,
     string? Descripcion,
     List<VehiculoDto> Vehiculos
 ) : IRequest<long>;
}
