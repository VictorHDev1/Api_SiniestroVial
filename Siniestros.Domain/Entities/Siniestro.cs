using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siniestros.Domain.Enums;

namespace Siniestros.Domain.Entities
{
    public class Siniestro
    {
        public long Id { get; private set; } 
        public DateTime FechaHora { get; private set; }
        public string Departamento { get; private set; }
        public string Ciudad { get; private set; }
        public TipoSiniestro Tipo { get; private set; }
        public int NumeroVictimas { get; private set; }
        public string? Descripcion { get; private set; }

        private readonly List<Vehiculo> _vehiculos = new();
        public IReadOnlyCollection<Vehiculo> Vehiculos => _vehiculos;

        protected Siniestro() { } // EF Core

        public Siniestro(
            DateTime fechaHora,
            string departamento,
            string ciudad,
            TipoSiniestro tipo,
            int numeroVictimas,
            string? descripcion)
        {
            FechaHora = fechaHora;
            Departamento = departamento;
            Ciudad = ciudad;
            Tipo = tipo;
            NumeroVictimas = numeroVictimas;
            Descripcion = descripcion;
        }

        public void AgregarVehiculo(Vehiculo vehiculo)
        {
            _vehiculos.Add(vehiculo);
        }
    }
}
