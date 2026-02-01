using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Siniestros.Domain.Entities;
using Siniestros.Application.Interfaces;


namespace Siniestros.Application.Commands.RegistrarSiniestro
{
    public class RegistrarSiniestroHandler
      : IRequestHandler<RegistrarSiniestroCommand, long>
    {
        private readonly ISiniestroRepository _repository;

        public RegistrarSiniestroHandler(ISiniestroRepository repository)
        {
            _repository = repository;
        }

        public async Task<long> Handle(
            RegistrarSiniestroCommand request,
            CancellationToken cancellationToken)
        {
            var siniestro = new Siniestro(
                request.FechaHora,
                request.Departamento,
                request.Ciudad,
                request.Tipo,
                request.NumeroVictimas,
                request.Descripcion);

            foreach (var v in request.Vehiculos)
            {
                siniestro.AgregarVehiculo(new Vehiculo(v.Tipo, v.Placa));
            }

            await _repository.AddAsync(siniestro);
            return siniestro.Id; 
        }
    }
}
