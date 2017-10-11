using SBP.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SBP.Domain.Interfaces.Repositories
{
    public interface ICidadeRepository
    {
        void Adicionar(Cidade cidade);

        void Atualizar(Cidade cidade);

        void Remover(Guid id);

        Cidade ObterPorId(Guid id);

        IEnumerable<Cidade> ObterTodos();

        IEnumerable<Cidade> ObterTodos(Guid idEstado);

        IEnumerable<Cidade> Buscar(Expression<Func<Cidade, bool>> predicate);        
    }
}
