using DomainValidation.Validation;
using SBP.Domain.Scopes;
using SBP.Domain.SharedKernel.Enum;
using SBP.Domain.SharedKernel.Helpers;
using SBP.Domain.SharedKernel.ValueObjects;
using System;

namespace SBP.Domain.Entidades
{
    public class Usuario
    {
        #region "Constantes"

        public const int SenhaMinLength = 6;
        public const int SenhaMaxLength = 30;

        #endregion

        protected Usuario()
        {
        }

        public Usuario(string email, string senha, int idPerfil, bool estaAtivo, Guid? idPessoa)
        {
            IdPessoa = idPessoa.Value;

            DefinirEmail(email);
            DefinirSenha(senha);

            DataDeCadastro = DateTime.Now;
            DataDeAtualizacao = null;
            DataDoUltimoLogin = null;
            Perfil = (EPerfil)idPerfil;
            EstaAtivo = estaAtivo;
        }

        #region "Propriedades"

        public Guid IdPessoa { get; private set; }

        public Email Email { get; private set; }

        public string Senha { get; private set; }

        public EPerfil Perfil { get; private set; }

        public DateTime DataDeCadastro { get; private set; }

        public DateTime? DataDeAtualizacao { get; set; }

        public DateTime? DataDoUltimoLogin { get; set; }               

        public Pessoa Pessoa { get; set; }

        public bool EstaAtivo { get; private set; }
        
        public ValidationResult ValidationResult { get; set; }

        #endregion

        #region "Métodos"

        private void DefinirEmail(string email)
        {
            var objEmail = new Email(email);

            if (this.DefinirEmailUsuarioScopeEhValido(objEmail))
                Email = objEmail;
        }

        private void DefinirSenha(string senha)
        {
            if (this.DefinirSenhaUsuarioScopeEhValido(senha))
                Senha = PasswordHelper.Criptografar(senha);
        }

        public bool Autenticar(string email, string senha)
        {
            if (this.AutenticarUsuarioScopeEhValido(email, senha))
                return true;

            return false;
        }

        public void AtualizarDados(string email, int idPerfil, bool estaAtivo)
        {
            DataDeAtualizacao = DateTime.Now;
            DefinirEmail(email);          
            Perfil = (EPerfil)idPerfil;
            EstaAtivo = estaAtivo;
        }

        public void AlterarStatusDeAtivacao(bool estaAtivo)
        {
            DataDeAtualizacao = DateTime.Now;
            EstaAtivo = estaAtivo;
        }

        public void AlterarSenha(string senha)
        {
            DataDeAtualizacao = DateTime.Now;
            DefinirSenha(senha);
        }

        #endregion
    }
}
