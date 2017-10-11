using DomainValidation.Validation;
using SBP.Domain.Scopes;
using SBP.Domain.SharedKernel.Helpers;
using SBP.Domain.SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;

namespace SBP.Domain.Entidades
{
    public abstract class Pessoa
    {
        private IList<Endereco> _enderecos;

        #region "Constantes"

        public const int NomeMinLength = 6;
        public const int NomeMaxLength = 200;

        #endregion

        protected Pessoa()
        {
        }

        public Pessoa(string nome, string cpf, string celular, Guid? idPessoa, string imagem)
        {
            IdPessoa = idPessoa == null ? Guid.NewGuid() : idPessoa.Value;
            DefinirNome(nome);
            DefinirCPF(cpf);
            DefinirCelular(celular);
            DefinirImagem(imagem);

            ListaDeEnderecos = new List<Endereco>();
        }

        #region "Propriedades"

        public Guid IdPessoa { get; private set; }

        public string Nome { get; private set; }

        public CPF CPF { get; private set; }

        public Telefone Celular { get; private set; }

        public Email Email { get; private set; }

        public byte[] Imagem { get; private set; }

        public Usuario Usuario { get; private set; }

        public virtual ICollection<Endereco> ListaDeEnderecos
        {
            get { return _enderecos; }
            private set { _enderecos = new List<Endereco>(value); }
        }

        public ValidationResult ValidationResult { get; set; }

        #endregion

        #region "Metodos"

        protected void DefinirNome(string nome)
        {
            if (!this.DefinirNomeScopeEhValido(nome))
                return;

            Nome = nome;
        }

        public void DefinirCPF(string cpf)
        {
            var tempCpf = new CPF(TextoHelper.GetNumeros(cpf));

            if (!this.DefinirCPFScopeEhValido(tempCpf))
                return;

            CPF = tempCpf;
        }

        public void DefinirCelular(string celular)
        {
            var tempCelular = new Telefone(celular);

            if (!this.DefinirCelularScopeEhValido(tempCelular))
                return;

            tempCelular = new Telefone(TextoHelper.GetNumeros(tempCelular.Numero));

            Celular = tempCelular;
        }

        public void DefinirEmail(string email)
        {
            var objEmail = new Email(email);

            if (this.DefinirEmailScopeEhValido(objEmail))
                Email = objEmail;
        }

        public void DefinirImagem(string imagem)
        {
            if (string.IsNullOrEmpty(imagem)) return;

            Imagem = ImageHelper.ConverterParaBytes(imagem);
        }

        public void DefinirUsuario(Usuario usuario)
        {
            if (usuario != null) Usuario = usuario;
        }

        public void AdicionarEndereco(Endereco endereco)
        {
            _enderecos.Add(endereco);
        }

        #endregion
    }
}
