using SBP.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using SBP.Infra.Data.UoW;
using SBP.Domain.Interfaces.Services;
using SBP.Application.Command;
using SBP.Application.Adapters;

namespace SBP.Application
{
    public class FuncionarioApp : BaseApp, IFuncionarioApp
    {
        private readonly IFuncionarioService _funcionarioService;
        private readonly IEnderecoService _enderecoService;
        private readonly IEstabelecimentoService _estabelecimentoService;

        public FuncionarioApp(IFuncionarioService funcionarioService, IEnderecoService enderecoService, IEstabelecimentoService estabelecimentoService,
                              IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _funcionarioService = funcionarioService;
            _enderecoService = enderecoService;
            _estabelecimentoService = estabelecimentoService;
        }

        public FuncionarioCommand Cadastrar(FuncionarioCommand funcionarioCommand)
        {
            var funcionario = _funcionarioService.Adicionar(FuncionarioAdapter.ToDomainModel(funcionarioCommand));

            if (Commit())
                return FuncionarioAdapter.ToModelDomain(funcionario);

            return null;
        }  

        public FuncionarioCommand Atualizar(FuncionarioCommand funcionarioCommand)
        {
            var funcionario = _funcionarioService.ObterPorId(funcionarioCommand.IdPessoa.Value);

            funcionario.AtualizarDados(funcionarioCommand.Nome, funcionarioCommand.CPF, funcionarioCommand.Celular, 
                                       funcionarioCommand.Email, funcionarioCommand.Funcao, funcionarioCommand.Imagem);

            var funcionarioRetorno = _funcionarioService.Atualizar(funcionario);

            var endereco = _enderecoService.ObterEnderecoPorIdPessoa(funcionarioCommand.IdPessoa.Value);

            endereco.AtualizarDados(funcionarioCommand.Endereco.Logradouro, funcionarioCommand.Endereco.Numero, funcionarioCommand.Endereco.Complemento,
                                    funcionarioCommand.Endereco.Bairro, funcionarioCommand.Endereco.CidadeId, funcionarioCommand.Endereco.EstadoId, 
                                    funcionarioCommand.Endereco.Cep);

            var enderecoRetorno = _enderecoService.Atualizar(endereco);

            funcionarioRetorno.AdicionarEndereco(enderecoRetorno);

            funcionarioRetorno.DefinirEstabelecimento(_estabelecimentoService.ObterPorId(funcionarioRetorno.EstabelecimentoId));

            if (Commit())
            {
                funcionarioRetorno.AnularEstabelecimento();
                return FuncionarioAdapter.ToModelDomain(funcionarioRetorno);
            }                

            return null;
        }

        public FuncionarioCommand ObterPorId(Guid id)
        {
            var funcionario = _funcionarioService.ObterPorId(id);
            funcionario.AdicionarEndereco(_enderecoService.ObterEnderecoPorIdPessoa(funcionario.IdPessoa));

            return FuncionarioAdapter.ToModelDomain(funcionario);
        }

        public IEnumerable<FuncionarioCommand> ObterTodos()
        {
            var lista = new List<FuncionarioCommand>();

            _funcionarioService.ObterTodos().ToList().ForEach(m => lista.Add(FuncionarioAdapter.ToModelDomain(m)));

            return lista;
        }

        public IEnumerable<FuncionarioCommand> ObterTodosPorEstabelecimentoEhStatus(Guid idEstabelecimento, bool ativo)
        {
            var lista = new List<FuncionarioCommand>();

            _funcionarioService.ObterTodosPorEstabelecimentoEhStatus(idEstabelecimento, ativo).ToList()
                               .ForEach(m => lista.Add(FuncionarioAdapter.ToModelDomain(m)));

            return lista;
        }

        public bool AlterarStatusDeAtivacao(Guid idFuncionario, bool estaAtivo)
        {
            _funcionarioService.AlterarStatusDeAtivacao(idFuncionario, estaAtivo);
            //_usuarioService.AlterarStatusDeAtivacao(idFuncionario, estaAtivo);

            return Commit();
        }

        public bool AlterarStatusDeAtivacaoDoFuncionario(Guid idFuncionario, bool estaAtivo)
        {
            _funcionarioService.AlterarStatusDeAtivacao(idFuncionario, estaAtivo);

            return Commit();
        }
    }
}
