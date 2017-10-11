using SBP.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using SBP.Application.Command;
using SBP.Infra.Data.UoW;
using SBP.Domain.Interfaces.Services;
using SBP.Application.Adapters;

namespace SBP.Application
{
    public class CidadeApp : BaseApp, ICidadeApp
    {
        private readonly ICidadeService _cidadeService;

        public CidadeApp(ICidadeService cidadeService, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _cidadeService = cidadeService;
        }

        public IEnumerable<CidadeCommand> ObterTodos(Guid idEstado)
        {
            var lista = new List<CidadeCommand>();

            _cidadeService.ObterTodos(idEstado).ToList().ForEach(m => lista.Add(CidadeAdapter.ToModelDomain(m)));

            return lista;
        }
    }
}
