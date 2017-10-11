using SBP.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBP.Application.Command;
using SBP.Infra.Data.UoW;
using SBP.Domain.Interfaces.Services;
using SBP.Application.Adapters;

namespace SBP.Application
{
    public class ClienteApp : BaseApp, IClienteApp
    {
        private readonly IClienteService _clienteService;
        private readonly IEnderecoService _enderecoService;

        public ClienteApp(IClienteService clienteService, IEnderecoService enderecoService, IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {
            _clienteService = clienteService;
            _enderecoService = enderecoService;
        }

        public ClienteCommand Cadastrar(ClienteCommand clienteCommand)
        {
            var cliente = _clienteService.Adicionar(ClienteAdapter.ToDomainModel(clienteCommand));

            if (Commit())
                return ClienteAdapter.ToModelDomain(cliente);

            return null;
        }

        public ClienteCommand Atualizar(ClienteCommand clienteCommand)
        {
            var cliente = _clienteService.ObterPorId(clienteCommand.IdPessoa.Value);

            cliente.AtualizarDados(clienteCommand.Nome, clienteCommand.CPF, clienteCommand.Celular, 
                                   clienteCommand.Email, clienteCommand.DataDeNascimento.Value);

            var clienteRetorno = _clienteService.Atualizar(cliente);

            var endereco = _enderecoService.ObterEnderecoPorIdPessoa(clienteCommand.IdPessoa.Value);

            endereco.AtualizarDados(clienteCommand.Endereco.Logradouro, clienteCommand.Endereco.Numero, clienteCommand.Endereco.Complemento,
                                    clienteCommand.Endereco.Bairro, clienteCommand.Endereco.CidadeId, clienteCommand.Endereco.EstadoId,
                                    clienteCommand.Endereco.Cep);

            var enderecoRetorno = _enderecoService.Atualizar(endereco);

            clienteRetorno.AdicionarEndereco(enderecoRetorno);

            if (Commit())
                return ClienteAdapter.ToModelDomain(clienteRetorno);

            return null;
        }
        
        public ClienteCommand ObterPorId(Guid id)
        {
            var cliente = _clienteService.ObterPorId(id);
            cliente.AdicionarEndereco(_enderecoService.ObterEnderecoPorIdPessoa(cliente.IdPessoa));

            return ClienteAdapter.ToModelDomain(cliente);
        }

        public IEnumerable<ClienteCommand> ObterTodos()
        {
            var lista = new List<ClienteCommand>();

            _clienteService.ObterTodos().ToList().ForEach(m => lista.Add(ClienteAdapter.ToModelDomain(m)));

            return lista;
        }

        public ClienteCommand ObterPorCPF(string cpf)
        {
            return ClienteAdapter.ToModelDomain(_clienteService.ObterPorCPF(cpf));
        }
    }
}
