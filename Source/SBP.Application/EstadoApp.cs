using SBP.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using SBP.Application.Command;
using SBP.Infra.Data.UoW;
using SBP.Domain.Interfaces.Services;
using SBP.Application.Adapters;

namespace SBP.Application
{
    public class EstadoApp : BaseApp, IEstadoApp
    {
        private readonly IEstadoService _estadoService;

        public EstadoApp(IEstadoService estadoService, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _estadoService = estadoService;
        }

        public IEnumerable<EstadoCommand> ObterTodos()
        {
            var lista = new List<EstadoCommand>();

            _estadoService.ObterTodos().ToList().ForEach(m => lista.Add(EstadoAdapter.ToModelDomain(m)));

            return lista;
        }
    }
}
