using SBP.Domain.Entidades;
using SBP.Domain.SharedKernel.Enum;
using System;
using System.Collections.Generic;

namespace SBP.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Usuario Adicionar(Usuario usuario);

        Usuario Atualizar(Usuario usuario);

        Usuario Autenticar(string email, string senha);

        Usuario AtualizarSenha(string senha, Guid idPessoa);

        Usuario ObterPorId(Guid id);

        Usuario ObterPorEmail(string email);

        void AlterarStatusDeAtivacao(Guid idUsuario, bool estaAtivo);

        IEnumerable<Usuario> ObterTodos();

        IEnumerable<EPerfil> ObterTodosOsPerfisPermitidos();
    }
}
