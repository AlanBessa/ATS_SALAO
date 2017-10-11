using SBP.Application.Interfaces;
using System;
using SBP.Application.Command;
using SBP.Domain.SharedKernel.Helpers;
using SBP.Infra.Data.UoW;
using SBP.Domain.Interfaces.Services;
using SBP.Application.Adapters;
using System.Collections.Generic;

namespace SBP.Application
{
    public class UsuarioApp : BaseApp, IUsuarioApp
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IFuncionarioService _funcionarioService;
        private readonly IEstabelecimentoService _estabelecimentoService;

        public UsuarioApp(IFuncionarioService funcionarioService, IUsuarioService usuarioService, IEstabelecimentoService estabelecimentoService, 
                          IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _usuarioService = usuarioService;
            _funcionarioService = funcionarioService;
            _estabelecimentoService = estabelecimentoService;
        }

        public UsuarioCommand Cadastrar(UsuarioCommand usuarioCommand)
        {
            var usuario = _usuarioService.Adicionar(UsuarioAdapter.ToDomainModel(usuarioCommand));
            _funcionarioService.AlterarStatusDeAtivacao(usuario.IdPessoa, usuario.EstaAtivo);

            if (Commit())
                return UsuarioAdapter.ToModelDomain(usuario);

            return null;
        }

        public UsuarioCommand Atualizar(UsuarioCommand usuarioCommand)
        {
            var usuario = _usuarioService.ObterPorId(usuarioCommand.IdPessoa.Value);

            usuario.AtualizarDados(usuarioCommand.Email, usuarioCommand.Perfil, usuarioCommand.EstaAtivo);

            var usuarioRetorno = _usuarioService.Atualizar(usuario);
            
            if (Commit())
                return UsuarioAdapter.ToModelDomain(usuarioRetorno);

            return null;
        }

        public UsuarioCommand AtualizarSenha(UsuarioCommand usuarioCommand)
        {
            var usuario = _usuarioService.AtualizarSenha(usuarioCommand.Senha, usuarioCommand.IdPessoa.Value);

            if (Commit())
                return UsuarioAdapter.ToModelDomain(usuario);

            return null;
        }

        public UsuarioCommand ObterPorId(Guid id)
        {
            return UsuarioAdapter.ToModelDomain(_usuarioService.ObterPorId(id));
        }

        public IEnumerable<UsuarioCommand> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public bool EnviarContatoPorEmail(ContatoCommand contato)
        {
            try
            {
                EmailHelper.EnviarEmail(
                    EmailHelper.FormatarTemplateDeContato(contato.Nome, contato.Email, contato.Celular, contato.Mensagem),
                    true);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public UsuarioCommand Autenticar(string userName, string senha)
        {
            var usuarioRetorno = UsuarioAdapter.ToModelDomain(_usuarioService.Autenticar(userName, senha));
            
            if(usuarioRetorno != null)
            {
                var funcionarioRetorno = FuncionarioAdapter.ToModelDomain(_funcionarioService.ObterPorId(usuarioRetorno.IdPessoa.Value));

                if(funcionarioRetorno != null) usuarioRetorno.Funcionario = funcionarioRetorno;
            }

            return usuarioRetorno;
        }
    }
}
