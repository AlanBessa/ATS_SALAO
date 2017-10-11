using SBP.Application.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using SBP.Infra.Data.UoW;
using SBP.Application.Command;
using SBP.Domain.Interfaces.Services;
using SBP.Application.Adapters;

namespace SBP.Application
{
    public class AgendaApp : BaseApp, IAgendaApp
    {
        private readonly IAgendaService _agendaService;
        private readonly ITipoDeServicoService _tipoDeServicoService;
        private readonly IClienteService _clienteService;

        public AgendaApp(IClienteService clienteService, ITipoDeServicoService tipoDeServicoService, IAgendaService agendaService, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _agendaService = agendaService;
            _tipoDeServicoService = tipoDeServicoService;
            _clienteService = clienteService;
        }

        public AgendaCommand Cadastrar(AgendaCommand agendaCommand)
        {
            if (agendaCommand.TipoDeServicoId == null) return null;

            var tipoDeServico = _tipoDeServicoService.ObterPorId(agendaCommand.TipoDeServicoId.Value);
            var agenda = AgendaAdapter.ToDomainModel(agendaCommand);
            agenda.CalcularDataFimAgendamentoPeloTipoDeServico(tipoDeServico.TempoGastoEmMinutos);

            var agendaRetorno = _agendaService.Adicionar(agenda);

            if (Commit())
                return AgendaAdapter.ToModelDomain(_agendaService.ObterPorId(agendaRetorno.IdAgenda));

            return null;
        }

        public AgendaCommand Atualizar(AgendaCommand agendaCommand)
        {
            throw new NotImplementedException();
        }
        
        public AgendaCommand ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AgendaCommand> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AgendaCommand> ObterTodosPorEstabelecimento(Guid id)
        {
            var lista = new List<AgendaCommand>();

            _agendaService.ObterTodosPorEstabelecimento(id).ToList().ForEach(m => lista.Add(AgendaAdapter.ToModelDomain(m)));

            return lista;
        }

        public IEnumerable<AgendaCommand> ObterTodosPor(Guid idEstabelecimento, Guid idFuncionario)
        {
            var lista = new List<AgendaCommand>();

            _agendaService.ObterTodosPor(idEstabelecimento, idFuncionario).ToList().ForEach(m => lista.Add(AgendaAdapter.ToModelDomain(m)));

            return lista;
        }
    }
}
