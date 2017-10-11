using SBP.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SBP.Domain.Interfaces.Repositories
{
    public interface IAgendaRepository
    {
        void Adicionar(Agenda agenda);

        void Atualizar(Agenda agenda);

        void Remover(Guid id);

        Agenda ObterPorId(Guid id);

        Agenda ObterPorFiltro(DateTime dataInicio, Guid idFuncionario, Guid idEstabelecimento);

        IEnumerable<Agenda> ObterTodos();

        IEnumerable<Agenda> ObterTodosPorEstabelecimento(Guid idEstabelecimento);

        IEnumerable<Agenda> ObterTodosPor(Guid idEstabelecimento, Guid idFuncionario);

        IEnumerable<Agenda> Buscar(Expression<Func<Agenda, bool>> predicate);
    }
}
