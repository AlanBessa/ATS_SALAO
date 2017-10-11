using SBP.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using SBP.Domain.Entidades;
using SBP.Infra.Data.Context;

namespace SBP.Infra.Data.Repositories
{
    public class EstadoRepository : IEstadoRepository
    {
        private readonly SalaoAgendadorContext _context;

        public EstadoRepository(SalaoAgendadorContext context)
        {
            _context = context;
        }

        public IEnumerable<Estado> ObterTodos()
        {
            return _context.Estados.ToList();
        }
    }
}
