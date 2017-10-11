using SBP.Application.Command;
using SBP.Domain.Entidades;

namespace SBP.Application.Adapters
{
    public class UsuarioAdapter
    {
        public static Usuario ToDomainModel(UsuarioCommand usuarioCommand)
        {
            var usuario = new Usuario(
                usuarioCommand.Email,
                usuarioCommand.Senha,
                usuarioCommand.Perfil,
                usuarioCommand.EstaAtivo,
                usuarioCommand.IdPessoa);

            return usuario;
        }

        public static UsuarioCommand ToModelDomain(Usuario usuario)
        {
            if (usuario == null) return null;

            var usuarioCommand = new UsuarioCommand(
                usuario.Email.Endereco,
                string.Empty,
                (int)usuario.Perfil,
                usuario.EstaAtivo,
                usuario.IdPessoa);

            return usuarioCommand;
        }
    }
}
