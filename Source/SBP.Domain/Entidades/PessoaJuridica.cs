using DomainValidation.Validation;
using SBP.Domain.Scopes;
using SBP.Domain.SharedKernel.Helpers;
using SBP.Domain.SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;

namespace SBP.Domain.Entidades
{
    public abstract class PessoaJuridica
    {
        private IList<EnderecoJuridico> _enderecosJuridicos;

        #region "Constantes"

        public const int TamanhoMinLength = 6;
        public const int TamanhoMaxLength = 100;

        #endregion

        protected PessoaJuridica()
        {
        }

        public PessoaJuridica(string razaoSocial, string nomeFantasia, string email, string cnpj, string telefone, Guid? idPessoaJuridica)
        {
            IdPessoaJuridica = idPessoaJuridica == null ? Guid.NewGuid() : idPessoaJuridica.Value;

            DefinirRazaoSocial(razaoSocial);
            DefinirNomeFantasia(nomeFantasia);
            DefinirCNPJ(cnpj);
            DefinirEmail(email);
            DefinirTelefone(telefone);

            ListaDeEnderecosJuridicos = new List<EnderecoJuridico>();
        }

        #region "Propriedades"

        public Guid IdPessoaJuridica { get; private set; }

        public string RazaoSocial { get; private set; }

        public string NomeFantasia { get; private set; }

        public Email Email { get; private set; }

        public CNPJ CNPJ { get; private set; }

        public Telefone Telefone { get; private set; }

        public ICollection<EnderecoJuridico> ListaDeEnderecosJuridicos
        {
            get { return _enderecosJuridicos; }
            private set { _enderecosJuridicos = new List<EnderecoJuridico>(value); }
        }

        public ValidationResult ValidationResult { get; set; }

        #endregion

        #region "Metodos"

        public void DefinirRazaoSocial(string razaoSocial)
        {
            if (!this.DefinirRazaoSocialPessoaJuridicaScopeEhValido(razaoSocial))
                return;

            RazaoSocial = razaoSocial;
        }

        public void DefinirNomeFantasia(string nomeFantasia)
        {
            if (!this.DefinirNomeFantasiaPessoaJuridicaScopeEhValido(nomeFantasia))
                return;

            NomeFantasia = nomeFantasia;
        }

        public void DefinirCNPJ(string cnpj)
        {
            var tempCNPJ = new CNPJ(TextoHelper.GetNumeros(cnpj));

            //Verificar se vai ser necessario limpar o cnpj dos caractes especiais

            if (!this.DefinirCNPJPessoaJuridicaScopeEhValido(tempCNPJ))
                return;

            CNPJ = tempCNPJ;
        }

        public void DefinirEmail(string email)
        {
            var tempEmail = new Email(email);

            if (!this.DefinirEmailPessoaJuridicaScopeEhValido(tempEmail))
                return;

            Email = tempEmail;
        }

        public void DefinirTelefone(string telefone)
        {
            var tempTelefone = new Telefone(telefone);

            if (!this.DefinirTelefonePessoaJuridicaScopeEhValido(tempTelefone))
                return;

            tempTelefone = new Telefone(TextoHelper.GetNumeros(tempTelefone.Numero));

            Telefone = tempTelefone;
        }

        public void AdicionarEndereco(EnderecoJuridico enderecoJuridico)
        {
            _enderecosJuridicos.Add(enderecoJuridico);
        }

        #endregion
    }
}
