using SBP.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SBP.Domain.Interfaces.Repositories
{
    public interface IEnderecoJuridicoRepository
    {
        void Adicionar(EnderecoJuridico enderecoJuridico);

        void Atualizar(EnderecoJuridico enderecoJuridico);

        void Remover(Guid id);

        EnderecoJuridico ObterPorId(Guid id);

        EnderecoJuridico ObterPorPessoaJuridicoId(Guid idPessoaJuridico);

        IEnumerable<EnderecoJuridico> ObterTodos();

        IEnumerable<EnderecoJuridico> Buscar(Expression<Func<EnderecoJuridico, bool>> predicate);
    }
}
