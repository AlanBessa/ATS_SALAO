using SBP.Application.Adapters;
using SBP.Application.Command;
using SBP.Application.Interfaces;
using SBP.Domain.Interfaces.Services;
using SBP.Infra.Data.UoW;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SBP.Application
{
    public class EstabelecimentoApp : BaseApp, IEstabelecimentoApp
    {
        private readonly IEstabelecimentoService _estabelecimentoService;
        private readonly IFuncionarioService _funcionarioService;
        private readonly IUsuarioService _usuarioService;
        private readonly IEnderecoJuridicoService _enderecoJuridicoService;

        public EstabelecimentoApp(IEstabelecimentoService estabelecimentoService, IEnderecoJuridicoService enderecoJuridicoService,
            IFuncionarioService funcionarioService, IUsuarioService usuarioService, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _estabelecimentoService = estabelecimentoService;
            _enderecoJuridicoService = enderecoJuridicoService;
            _usuarioService = usuarioService;
            _funcionarioService = funcionarioService;
        }

        public EstabelecimentoCommand Cadastrar(FuncionarioCommand funcionarioCommand)
        {
            var estabelecimento = _estabelecimentoService.Adicionar(EstabelecimentoAdapter.ToDomainModel(funcionarioCommand.Estabelecimento));
            funcionarioCommand.EstabelecimentoId = estabelecimento.IdPessoaJuridica;
            var funcionario = _funcionarioService.Adicionar(FuncionarioAdapter.ToDomainModel(funcionarioCommand));
            funcionarioCommand.Usuario.IdPessoa = funcionario.IdPessoa;
            var usuario = _usuarioService.Adicionar(UsuarioAdapter.ToDomainModel(funcionarioCommand.Usuario));

            if (Commit())
                //TODO: Verificar objeto recursivo
                return EstabelecimentoAdapter.ToModelDomain(estabelecimento);

            return null;
        }

        public EstabelecimentoCommand Atualizar(EstabelecimentoCommand estabelecimentoCommand)
        {
            var estabelecimento = _estabelecimentoService.ObterPorId(estabelecimentoCommand.IdPessoaJuridica.Value);

            estabelecimento.AtualizarDados(estabelecimentoCommand.RazaoSocial, estabelecimentoCommand.NomeFantasia, estabelecimentoCommand.Email,
                                           estabelecimentoCommand.CNPJ, estabelecimentoCommand.Telefone, estabelecimentoCommand.Descricao, estabelecimentoCommand.Logo);

            var funcionarioRetorno = _estabelecimentoService.Atualizar(estabelecimento);

            var endereco = _enderecoJuridicoService.ObterEnderecoJuridicoPorIdPessoaJuridico(estabelecimentoCommand.IdPessoaJuridica.Value);

            endereco.AtualizarDados(estabelecimentoCommand.EnderecoJuridico.Logradouro, estabelecimentoCommand.EnderecoJuridico.Numero, estabelecimentoCommand.EnderecoJuridico.Complemento,
                                    estabelecimentoCommand.EnderecoJuridico.Bairro, estabelecimentoCommand.EnderecoJuridico.CidadeId, estabelecimentoCommand.EnderecoJuridico.EstadoId,
                                    estabelecimentoCommand.EnderecoJuridico.Cep);

            var enderecoRetorno = _enderecoJuridicoService.Atualizar(endereco);

            funcionarioRetorno.AdicionarEndereco(enderecoRetorno);

            if (Commit())
                return EstabelecimentoAdapter.ToModelDomain(funcionarioRetorno);

            return null;
        }

        public EstabelecimentoCommand ObterPorId(Guid id)
        {
            var estabelecimento = _estabelecimentoService.ObterPorId(id);
            estabelecimento.AdicionarEndereco(_enderecoJuridicoService.ObterEnderecoJuridicoPorIdPessoaJuridico(estabelecimento.IdPessoaJuridica));

            return EstabelecimentoAdapter.ToModelDomain(estabelecimento);
        }

        public IEnumerable<EstabelecimentoCommand> ObterTodos()
        {
            var lista = new List<EstabelecimentoCommand>();

            _estabelecimentoService.ObterTodos().ToList().ForEach(m => lista.Add(EstabelecimentoAdapter.ToModelDomain(m)));

            return lista;
        }

        public IEnumerable<EstabelecimentoCommand> ObterTodosPorStatus(bool ativo)
        {
            var lista = new List<EstabelecimentoCommand>();

            _estabelecimentoService.ObterTodosPorStatus(ativo).ToList().ForEach(m => lista.Add(EstabelecimentoAdapter.ToModelDomain(m)));

            return lista;
        }

        public bool AlterarStatusDeAtivacao(Guid idEstabelecimento, bool estaAtivo)
        {
            var estabelecimento = _estabelecimentoService.ObterPorId(idEstabelecimento);

            estabelecimento.AlterarStatusDeAtivacao(estaAtivo);

            _estabelecimentoService.Atualizar(estabelecimento);

            return Commit();
        }
    }
}
