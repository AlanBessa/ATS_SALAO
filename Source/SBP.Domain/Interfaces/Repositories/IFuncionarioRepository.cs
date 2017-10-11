using SBP.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SBP.Domain.Interfaces.Repositories
{
    public interface IFuncionarioRepository
    {
        void Adicionar(Funcionario funcionario);

        void Atualizar(Funcionario funcionario);

        void Remover(Guid id);

        Funcionario ObterPorId(Guid id);

        Funcionario ObterPorCPF(string cpf);

        Funcionario ObterPrimeiroFuncionarioPorEstabelecimento(Guid idEstabelecimento);

        IEnumerable<Funcionario> ObterTodos();

        IEnumerable<Funcionario> Buscar(Expression<Func<Funcionario, bool>> predicate);
    }
}
