using Siniestros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siniestros.Application.Interfaces
{
    public interface ISiniestroRepository
    {
        Task AddAsync(Siniestro siniestro);
    }
}
