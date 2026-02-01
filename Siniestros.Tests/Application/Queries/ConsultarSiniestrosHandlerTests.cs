using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Siniestros.Application.Common;
using Siniestros.Application.DTOs;
using Siniestros.Application.Interfaces;
using Siniestros.Application.Queries.ConsultarSiniestros;
using Xunit;


namespace Siniestros.Tests.Application.Queries
{
    public class ConsultarSiniestrosHandlerTests
    {
        [Fact]
        public async Task Debe_Consultar_Siniestros()
        {
            var repoMock = new Mock<ISiniestroReadRepository>();

            var paged = new PagedResult<SiniestroDto>(
                new List<SiniestroDto>
                {
                    new()
                    {
                        Id = 1,
                        Departamento = "Antioquia",
                        Ciudad = "Medellin",
                        NumeroVictimas = 1
                    }
                },
                1,
                1,
                10
            );

            repoMock.Setup(r => r.GetAsync(
                It.IsAny<string>(),
                It.IsAny<DateTime?>(),
                It.IsAny<DateTime?>(),
                It.IsAny<int>(),
                It.IsAny<int>()))
                .ReturnsAsync(paged);

            var handler = new ConsultarSiniestrosHandler(repoMock.Object);

            var query = new ConsultarSiniestrosQuery(
                "Antioquia",
                null,
                null,
                1,
                10);

            var result = await handler.Handle(query, default);

            result.Items.Should().HaveCount(1);
        }
    }
}
