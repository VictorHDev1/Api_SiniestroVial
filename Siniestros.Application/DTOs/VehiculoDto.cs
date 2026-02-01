using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siniestros.Application.DTOs
{
    public class VehiculoDto
    {
        public string Tipo { get; set; } = default!;
        public string Placa { get; set; } = default!;
    }
}
