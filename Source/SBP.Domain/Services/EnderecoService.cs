using SBP.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBP.Domain.Entidades;
using SBP.Domain.Interfaces.Repositories;

namespace SBP.Domain.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public Endereco Atualizar(Endereco endereco)
        {
            _enderecoRepository.Atualizar(endereco);

            return endereco;
        }

        public Endereco ObterEnderecoPorIdPessoa(Guid idPessoa)
        {
            return _enderecoRepository.Buscar(m => m.PessoaId == idPessoa).SingleOrDefault();
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
