using Siniestros.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siniestros.Application.DTOs
{
    public class SiniestroDto
    {
        public long Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string Departamento { get; set; } = default!;
        public string Ciudad { get; set; } = default!;
        public TipoSiniestro Tipo { get; set; }
        public int NumeroVictimas { get; set; }
    }
}
