using Microsoft.AspNet.Identity;
using SBP.Application.Command;
using System;
using System.Collections.Generic;

namespace SBP.Application.Interfaces
{
    public interface IUsuarioApp
    {
        bool EnviarContatoPorEmail(ContatoCommand contato);

        UsuarioCommand Cadastrar(UsuarioCommand usuarioCommand);

        UsuarioCommand Atualizar(UsuarioCommand usuarioCommand);

        UsuarioCommand AtualizarSenha(UsuarioCommand usuarioCommand);

        UsuarioCommand ObterPorId(Guid id);

        IEnumerable<UsuarioCommand> ObterTodos();

        UsuarioCommand Autenticar(string userName, string senha);
    }
}
