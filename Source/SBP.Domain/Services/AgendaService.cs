using SBP.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using SBP.Domain.Entidades;
using SBP.Domain.Interfaces.Repositories;
using SBP.Domain.Validations;

namespace SBP.Domain.Services
{
    public class AgendaService : BaseService, IAgendaService
    {
        private readonly IAgendaRepository _agendaRepository;

        public AgendaService(IAgendaRepository agendaRepository)
        {
            _agendaRepository = agendaRepository;
        }

        public Agenda Adicionar(Agenda agenda)
        {
            if (!PossuiConformidade(new AgendaAptoParaCadastroValidation(_agendaRepository).Validate(agenda)))
                _agendaRepository.Adicionar(agenda);             

            return agenda;
        }

        public void AlterarStatusDeAtivacao(Guid idAgenda, bool estaAtivo)
        {
            throw new NotImplementedException();
        }

        public Agenda Atualizar(Agenda agenda)
        {
            throw new NotImplementedException();
        }

        public Agenda ObterPorId(Guid id)
        {
            return _agendaRepository.ObterPorId(id);
        }

        public IEnumerable<Agenda> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Agenda> ObterTodosPor(Guid idEstabelecimento, Guid idFuncionario)
        {
            return _agendaRepository.ObterTodosPor(idEstabelecimento, idFuncionario);
        }

        public IEnumerable<Agenda> ObterTodosPorEstabelecimento(Guid idEstabelecimento)
        {
            return _agendaRepository.ObterTodosPorEstabelecimento(idEstabelecimento);
        }

        public IEnumerable<Agenda> ObterTodosPorStatus(bool ativo)
        {
            throw new NotImplementedException();
        }
    }
}
