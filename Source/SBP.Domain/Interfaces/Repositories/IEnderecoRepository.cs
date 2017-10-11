using SBP.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SBP.Domain.Interfaces.Repositories
{
    public interface IEnderecoRepository
    {
        void Adicionar(Endereco endereco);

        void Atualizar(Endereco endereco);

        void Remover(Guid id);

        Endereco ObterPorId(Guid id);

        Endereco ObterPorPessoaId(Guid idPessoa);

        IEnumerable<Endereco> ObterTodos();

        IEnumerable<Endereco> Buscar(Expression<Func<Endereco, bool>> predicate);
    }
}
