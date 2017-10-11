using SBP.Domain.Interfaces.Services;
using System;
using System.Linq;
using SBP.Domain.Entidades;
using SBP.Domain.Interfaces.Repositories;

namespace SBP.Domain.Services
{
    public class EnderecoJuridicoService : BaseService, IEnderecoJuridicoService
    {
        private readonly IEnderecoJuridicoRepository _enderecoJuridicoRepository;

        public EnderecoJuridicoService(IEnderecoJuridicoRepository enderecoJuridicoRepository)
        {
            _enderecoJuridicoRepository = enderecoJuridicoRepository;
        }
        
        public EnderecoJuridico Atualizar(EnderecoJuridico enderecoJuridico)
        {
            _enderecoJuridicoRepository.Atualizar(enderecoJuridico);

            return enderecoJuridico;
        }

        public EnderecoJuridico ObterEnderecoJuridicoPorIdPessoaJuridico(Guid idPessoaJuridico)
        {
            return _enderecoJuridicoRepository.Buscar(m => m.PessoaJuridicaId == idPessoaJuridico).SingleOrDefault();
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
