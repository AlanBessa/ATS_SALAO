using SBP.Application.Command;
using System;
using System.Collections.Generic;

namespace SBP.Application.Interfaces
{
    public interface IAgendaApp
    {
        AgendaCommand Cadastrar(AgendaCommand agendaCommand);

        AgendaCommand Atualizar(AgendaCommand agendaCommand);

        AgendaCommand ObterPorId(Guid id);

        IEnumerable<AgendaCommand> ObterTodos();

        IEnumerable<AgendaCommand> ObterTodosPorEstabelecimento(Guid id);

        IEnumerable<AgendaCommand> ObterTodosPor(Guid idEstabelecimento, Guid idFuncionario);
    }
}
