using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siniestros.Domain.Entities
{
    public class Vehiculo
    {
        public long Id { get; private set; }
        public string Tipo { get; private set; }
        public string Placa { get; private set; }

        protected Vehiculo() { }

        public Vehiculo(string tipo, string placa)
        {
            Tipo = tipo;
            Placa = placa;
        }
    }
}
