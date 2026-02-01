using FluentAssertions;
using Moq;
using Siniestros.Application.Commands.RegistrarSiniestro;
using Siniestros.Application.DTOs;
using Siniestros.Application.Interfaces;
using Siniestros.Domain.Entities;
using Siniestros.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace Siniestros.Tests.Application.Commands
{
    public class RegistrarSiniestroHandlerTests
    {
        [Fact]
        public async Task Debe_Registrar_Siniestro()
        {
            var repoMock = new Mock<ISiniestroRepository>();

            repoMock
      .Setup(r => r.AddAsync(It.IsAny<Siniestro>()))
      .Returns(Task.CompletedTask);


            var handler = new RegistrarSiniestroHandler(repoMock.Object);

            var command = new RegistrarSiniestroCommand(
                DateTime.UtcNow,
                "Antioquia",
                "Medellin",
                TipoSiniestro.Colision,
                1,
                "Test",
                new List<VehiculoDto>()
            );

            var result = await handler.Handle(command, default);

            result.Should().Be(10);
        }
    }
}
