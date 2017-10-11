using SBP.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SBP.Domain.Interfaces.Repositories
{
    public interface ITipoDeServicoRepository
    {
        void Adicionar(TipoDeServico tipoDeServico);

        void Atualizar(TipoDeServico tipoDeServico);

        void Remover(TipoDeServico tipoDeServico);

        TipoDeServico ObterPorId(Guid id);

        IEnumerable<TipoDeServico> ObterTodos();

        List<TipoDeServico> ObterTodos(int skip, int take);

        IEnumerable<TipoDeServico> ObterTodosPor(Guid idEstabelecimento);

        IEnumerable<TipoDeServico> Buscar(Expression<Func<TipoDeServico, bool>> predicate);
    }
}
