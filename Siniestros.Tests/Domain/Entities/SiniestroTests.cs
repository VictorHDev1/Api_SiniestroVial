using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Siniestros.Domain.Entities;
using Siniestros.Domain.Enums;
using Xunit;


namespace Siniestros.Tests.Domain.Entities
{
    public class SiniestroTests
    {
        [Fact]
        public void Debe_Crear_Siniestro_Correctamente()
        {
            var fecha = DateTime.UtcNow;

            var siniestro = new Siniestro(
                fecha,
                "Antioquia",
                "Medellin",
                TipoSiniestro.Colision,
                2,
                "Prueba");

            siniestro.Departamento.Should().Be("Antioquia");
            siniestro.Ciudad.Should().Be("Medellin");
            siniestro.Tipo.Should().Be(TipoSiniestro.Colision);
            siniestro.NumeroVictimas.Should().Be(2);
        }

        [Fact]
        public void Debe_Agregar_Vehiculo()
        {
            var siniestro = new Siniestro(
                DateTime.UtcNow,
                "Antioquia",
                "Medellin",
                TipoSiniestro.Colision,
                1,
                null);

            var vehiculo = new Vehiculo("Carro", "ABC123");

            siniestro.AgregarVehiculo(vehiculo);

            siniestro.Vehiculos.Count.Should().Be(1);
        }
    }
}
