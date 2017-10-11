using SBP.Application.Command;
using System;
using System.Collections.Generic;

namespace SBP.Application.Interfaces
{
    public interface IClienteApp
    {
        ClienteCommand Cadastrar(ClienteCommand clienteCommand);

        ClienteCommand Atualizar(ClienteCommand clienteCommand);

        ClienteCommand ObterPorId(Guid id);

        ClienteCommand ObterPorCPF(string cpf);

        IEnumerable<ClienteCommand> ObterTodos();
    }
}
