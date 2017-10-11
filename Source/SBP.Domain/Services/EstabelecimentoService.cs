using SBP.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBP.Domain.Entidades;
using SBP.Domain.Interfaces.Repositories;
using SBP.Domain.Validations;

namespace SBP.Domain.Services
{
    public class EstabelecimentoService : BaseService, IEstabelecimentoService
    {
        private readonly IEstabelecimentoRepository _estabelecimentoRepository;
        private readonly IEnderecoJuridicoRepository _enderecoJuridicoRepository;
        private readonly IFuncionarioRepository _funcionarioRepository;

        public EstabelecimentoService(IEstabelecimentoRepository estabelecimentoRepository, IEnderecoJuridicoRepository enderecoJuridicoRepository,
                                      IFuncionarioRepository funcionarioRepository)
        {
            _estabelecimentoRepository = estabelecimentoRepository;
            _enderecoJuridicoRepository = enderecoJuridicoRepository;
            _funcionarioRepository = funcionarioRepository;
        }

        public Estabelecimento Adicionar(Estabelecimento estabelecimento)
        {
            if (!PossuiConformidade(new EstabelecimentoAptoParaCadastroValidation(_estabelecimentoRepository).Validate(estabelecimento)))
                _estabelecimentoRepository.Adicionar(estabelecimento);

            return estabelecimento;
        }

        public Estabelecimento Atualizar(Estabelecimento estabelecimento)
        {
            if (!PossuiConformidade(new EstabelecimentoAptoParaEdicaoValidation(_estabelecimentoRepository).Validate(estabelecimento)))
                _estabelecimentoRepository.Atualizar(estabelecimento);

            return estabelecimento;
        }

        public Estabelecimento ObterPorId(Guid id)
        {
            return _estabelecimentoRepository.ObterPorId(id);
        }

        public IEnumerable<Estabelecimento> ObterTodos()
        {
            var lista = _estabelecimentoRepository.ObterTodos().ToList();

            foreach (var item in lista)
            {
                item.AdicionarEndereco(_enderecoJuridicoRepository.ObterPorPessoaJuridicoId(item.IdPessoaJuridica));

                var funcionario = _funcionarioRepository.ObterPrimeiroFuncionarioPorEstabelecimento(item.IdPessoaJuridica);
                if (funcionario != null)
                {
                    funcionario.AnularEstabelecimento();
                    item.AdicionarFuncionario(funcionario);
                }
            }

            return lista;
        }

        public IEnumerable<Estabelecimento> ObterTodosPorStatus(bool ativo)
        {
            var lista = _estabelecimentoRepository.Buscar(m => m.EstaAtivo == ativo).ToList();

            foreach(var item in lista)
            {
                item.AdicionarEndereco(_enderecoJuridicoRepository.ObterPorPessoaJuridicoId(item.IdPessoaJuridica));

                var funcionario = _funcionarioRepository.ObterPrimeiroFuncionarioPorEstabelecimento(item.IdPessoaJuridica);
                if(funcionario != null)
                {
                    funcionario.AnularEstabelecimento();
                    item.AdicionarFuncionario(funcionario);
                }                
            }
            
            return lista;
        }
    }
}
