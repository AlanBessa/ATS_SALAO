using SBP.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SBP.Domain.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        void Adicionar(Cliente cliente);

        void Atualizar(Cliente cliente);

        void Remover(Guid id);

        Cliente ObterPorId(Guid id);

        Cliente ObterPorCPF(string cpf);
        
        IEnumerable<Cliente> ObterTodos();

        IEnumerable<Cliente> Buscar(Expression<Func<Cliente, bool>> predicate);
    }
}
