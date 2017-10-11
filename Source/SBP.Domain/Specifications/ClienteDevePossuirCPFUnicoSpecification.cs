using DomainValidation.Interfaces.Specification;
using SBP.Domain.Entidades;
using SBP.Domain.Interfaces.Repositories;

namespace SBP.Domain.Specifications
{
    public class ClienteDevePossuirCPFUnicoSpecification : ISpecification<Cliente>
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteDevePossuirCPFUnicoSpecification(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public bool IsSatisfiedBy(Cliente cliente)
        {
            var cli = _clienteRepository.ObterPorCPF(cliente.CPF.Codigo);

            return (cli == null || (cli != null && cli.IdPessoa == cliente.IdPessoa));
        }
    }
}
