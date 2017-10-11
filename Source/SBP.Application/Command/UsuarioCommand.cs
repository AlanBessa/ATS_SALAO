using System;

namespace SBP.Application.Command
{
    public class UsuarioCommand
    {
        public UsuarioCommand(string senha, Guid? idPessoa)
        {
            Senha = senha;
            IdPessoa = idPessoa;
        }

        public UsuarioCommand(string email, string senha, int perfil, bool estaAtivo, Guid? idPessoa)
        {
            Email = email;
            Senha = senha;
            Perfil = perfil;
            IdPessoa = idPessoa;
            EstaAtivo = estaAtivo;
        }
        
        public Guid? IdPessoa { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public int Perfil { get; set; }
        
        public DateTime DataDoUltimoLogin { get; set; }
                
        public bool EstaAtivo { get; set; }

        public FuncionarioCommand Funcionario { get; set; }

        public ClienteCommand Cliente { get; set; }
    }
}
