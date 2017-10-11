using SBP.Domain.Interfaces.Services;
using System;
using System.Linq;
using System.Collections.Generic;
using SBP.Domain.Entidades;
using SBP.Domain.Interfaces.Repositories;
using SBP.Domain.Validations;
using System.Text.RegularExpressions;
using SBP.Domain.SharedKernel.Helpers;

namespace SBP.Domain.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Cliente Adicionar(Cliente cliente)
        {
            if (!PossuiConformidade(new ClienteAptoParaCadastroValidation(_clienteRepository).Validate(cliente)))
                _clienteRepository.Adicionar(cliente);

            return cliente;
        }

        public Cliente Atualizar(Cliente cliente)
        {
            if (!PossuiConformidade(new ClienteAptaParaEdicaoValidation(_clienteRepository).Validate(cliente)))
                _clienteRepository.Atualizar(cliente);

            return cliente;
        }

        public Cliente ObterPorId(Guid id)
        {
            return _clienteRepository.ObterPorId(id);
        }

        public Cliente ObterPorCPF(string cpf)
        {
            return _clienteRepository.ObterPorCPF(TextoHelper.GetNumeros(cpf.Trim()));
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return _clienteRepository.ObterTodos();
        }
    }
}
