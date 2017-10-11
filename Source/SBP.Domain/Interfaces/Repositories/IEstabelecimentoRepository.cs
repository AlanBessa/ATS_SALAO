using SBP.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SBP.Domain.Interfaces.Repositories
{
    public interface IEstabelecimentoRepository
    {
        void Adicionar(Estabelecimento estabelecimento);

        void Atualizar(Estabelecimento estabelecimento);

        void Remover(Guid id);

        Estabelecimento ObterPorId(Guid id);

        Estabelecimento ObterPorCNPJ(string cnpj);

        IEnumerable<Estabelecimento> ObterTodos();

        IEnumerable<Estabelecimento> Buscar(Expression<Func<Estabelecimento, bool>> predicate);
    }
}
