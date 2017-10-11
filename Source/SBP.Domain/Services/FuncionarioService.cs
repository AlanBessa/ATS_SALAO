using SBP.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using SBP.Domain.Entidades;
using SBP.Domain.Interfaces.Repositories;
using SBP.Domain.Validations;

namespace SBP.Domain.Services
{
    public class FuncionarioService : BaseService, IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository, IUsuarioRepository usuarioRepository,
                                  IEnderecoRepository enderecoRepository) 
        {
            _funcionarioRepository = funcionarioRepository;
            _enderecoRepository = enderecoRepository;
            _usuarioRepository = usuarioRepository;
        }

        public Funcionario Adicionar(Funcionario funcionario)
        {
            if (!PossuiConformidade(new FuncionarioAptoParaCadastroValidation(_funcionarioRepository).Validate(funcionario)))
                _funcionarioRepository.Adicionar(funcionario);

            return funcionario;
        }

        public Funcionario Atualizar(Funcionario funcionario)
        {
            if (!PossuiConformidade(new FuncionarioAptaParaEdicaoValidation(_funcionarioRepository).Validate(funcionario)))
                _funcionarioRepository.Atualizar(funcionario);

            return funcionario;
        }

        public Funcionario ObterPorId(Guid id)
        {
            return _funcionarioRepository.ObterPorId(id);
        }

        public IEnumerable<Funcionario> ObterTodos()
        {
            var lista = _funcionarioRepository.ObterTodos();
            
            foreach(var item in lista)
            {
                item.AdicionarEndereco(_enderecoRepository.ObterPorPessoaId(item.IdPessoa));
                item.DefinirUsuario(_usuarioRepository.ObterPorPessoaId(item.IdPessoa));
            }

            return lista;
        }

        public IEnumerable<Funcionario> ObterTodosPorEstabelecimentoEhStatus(Guid idEstabelecimento, bool ativo)
        {
            var lista = _funcionarioRepository.Buscar(m => m.EstaAtivo == ativo && m.EstabelecimentoId == idEstabelecimento).ToList();

            foreach (var item in lista)
            {
                item.Estabelecimento.AnularListaDeFuncionario();

                item.AdicionarEndereco(_enderecoRepository.ObterPorPessoaId(item.IdPessoa));
                item.DefinirUsuario(_usuarioRepository.ObterPorPessoaId(item.IdPessoa));
            }

            return lista;
        }

        public void AlterarStatusDeAtivacao(Guid idFuncionario, bool estaAtivo)
        {
            var funcionario = _funcionarioRepository.ObterPorId(idFuncionario);
            funcionario.DefinirUsuario(_usuarioRepository.ObterPorPessoaId(funcionario.IdPessoa));

            funcionario.AlterarStatusDeAtivacao(estaAtivo);

            _funcionarioRepository.Atualizar(funcionario);
        }
    }
}
