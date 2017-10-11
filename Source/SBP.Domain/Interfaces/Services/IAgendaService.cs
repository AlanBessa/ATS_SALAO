using SBP.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace SBP.Domain.Interfaces.Services
{
    public interface IAgendaService
    {
        Agenda Adicionar(Agenda agenda);

        Agenda Atualizar(Agenda agenda);

        void AlterarStatusDeAtivacao(Guid idAgenda, bool estaAtivo);

        Agenda ObterPorId(Guid id);

        IEnumerable<Agenda> ObterTodos();

        IEnumerable<Agenda> ObterTodosPorStatus(bool ativo);

        IEnumerable<Agenda> ObterTodosPorEstabelecimento(Guid id);

        IEnumerable<Agenda> ObterTodosPor(Guid idEstabelecimento, Guid idFuncionario);
    }
}
