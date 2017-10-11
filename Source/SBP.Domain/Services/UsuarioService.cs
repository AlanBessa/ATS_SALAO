using SBP.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using SBP.Domain.Entidades;
using SBP.Domain.Interfaces.Repositories;
using SBP.Domain.Validations;
using SBP.Domain.SharedKernel.Enum;

namespace SBP.Domain.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario Adicionar(Usuario usuario)
        {
            if (!PossuiConformidade(new UsuarioAptoParaCadastroValidation(_usuarioRepository).Validate(usuario)))
                _usuarioRepository.Adicionar(usuario);

            return usuario;
        }
              
        public Usuario Atualizar(Usuario usuario)
        {
            if (!PossuiConformidade(new UsuarioAptaParaEdicaoValidation(_usuarioRepository).Validate(usuario)))
                _usuarioRepository.Atualizar(usuario);

            return usuario;
        }

        public void AlterarStatusDeAtivacao(Guid idUsuario, bool estaAtivo)
        {
            var usuario = _usuarioRepository.ObterPorId(idUsuario);

            if (usuario == null) return;

            usuario.AlterarStatusDeAtivacao(estaAtivo);

            _usuarioRepository.Atualizar(usuario);
        }

        public Usuario AtualizarSenha(string senha, Guid idPessoa)
        {
            var usuario = _usuarioRepository.ObterPorId(idPessoa);

            usuario.AlterarSenha(senha);

            _usuarioRepository.Atualizar(usuario);

            return usuario;
        }

        public Usuario Autenticar(string email, string senha)
        {
            var usuario = _usuarioRepository.ObterPorEmail(email);

            if (usuario == null) return null;

            if (usuario.Autenticar(email, senha)) return usuario;

            return null;
        }

        public Usuario ObterPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Usuario ObterPorId(Guid id)
        {
            return _usuarioRepository.ObterPorId(id);
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return _usuarioRepository.ObterTodos();
        }

        public IEnumerable<EPerfil> ObterTodosOsPerfisPermitidos()
        {
            return Enum.GetValues(typeof(EPerfil)).Cast<EPerfil>();
        }        
    }
}
