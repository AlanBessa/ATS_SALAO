using SBP.Application.Command;
using SBP.Domain.Entidades;
using SBP.Domain.SharedKernel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP.Application.Adapters
{
    public class ClienteAdapter
    {
        public static Cliente ToDomainModel(ClienteCommand clienteCommand)
        {
            var cliente = new Cliente(
                clienteCommand.DataDeNascimento,
                clienteCommand.Nome,
                clienteCommand.CPF,
                clienteCommand.Celular,
                clienteCommand.IdPessoa,
                clienteCommand.Imagem);

            if (!string.IsNullOrEmpty(clienteCommand.Email)) cliente.DefinirEmail(clienteCommand.Email);

            cliente.AdicionarEndereco(EnderecoAdapter.ToDomainModel(clienteCommand.Endereco));

            return cliente;
        }

        public static ClienteCommand ToModelDomain(Cliente cliente)
        {
            if (cliente == null) return null;

            var clienteCommand = new ClienteCommand(
                cliente.Nome,
                cliente.CPF.Codigo,
                cliente.Celular.Numero,
                cliente.Email.Endereco,
                cliente.DataDeNascimento,
                ImageHelper.ConverterParaBase64String(cliente.Imagem));

            clienteCommand.IdPessoa = cliente.IdPessoa;
            clienteCommand.Endereco = EnderecoAdapter.ToModelDomain(cliente.ListaDeEnderecos.FirstOrDefault());

            return clienteCommand;
        }
    }
}
