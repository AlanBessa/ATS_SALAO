using SBP.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace SBP.Domain.Interfaces.Services
{
    public interface IClienteService
    {
        Cliente Adicionar(Cliente cliente);

        Cliente Atualizar(Cliente cliente);

        Cliente ObterPorId(Guid id);

        Cliente ObterPorCPF(string cpf);

        IEnumerable<Cliente> ObterTodos();
    }
}
