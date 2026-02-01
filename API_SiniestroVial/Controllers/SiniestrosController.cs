using MediatR;
using Microsoft.AspNetCore.Mvc;
using Siniestros.Application.Commands.RegistrarSiniestro;
using Siniestros.Application.Queries.ConsultarSiniestros;

namespace API_SiniestroVial.Controllers
{
    [ApiController]
    [Route("api/siniestros")]
    public class SiniestrosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SiniestrosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Crear(
              [FromBody] RegistrarSiniestroCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(Crear), new { id }, null);
        }

        [HttpGet]
        [Route("ConsultaSiniestros")]
        public async Task<IActionResult> Consultar(
            [FromQuery] ConsultarSiniestrosQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}
