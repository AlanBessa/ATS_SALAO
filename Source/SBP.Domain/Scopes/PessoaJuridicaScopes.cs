using SBP.Domain.Entidades;
using SBP.Domain.SharedKernel.Resources;
using SBP.Domain.SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP.Domain.Scopes
{
    public static class PessoaJuridicaScopes
    {
        public static bool DefinirRazaoSocialPessoaJuridicaScopeEhValido(this PessoaJuridica pessoaJuridica, string razaoSocial)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(razaoSocial, ErrorMessage.RazaoSocialObrigatorio),
                AssertionConcern.AssertLength(razaoSocial, PessoaJuridica.TamanhoMinLength, PessoaJuridica.TamanhoMaxLength, ErrorMessage.RazaoSocialTamanhoInvalido)
            );
        }

        public static bool DefinirNomeFantasiaPessoaJuridicaScopeEhValido(this PessoaJuridica pessoaJuridica, string nomeFantasia)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(nomeFantasia, ErrorMessage.NomeFantasiaObrigatorio),
                AssertionConcern.AssertLength(nomeFantasia, PessoaJuridica.TamanhoMinLength, PessoaJuridica.TamanhoMaxLength, ErrorMessage.NomeFantasiaTamanhoInvalido)
            );
        }

        public static bool DefinirCNPJPessoaJuridicaScopeEhValido(this PessoaJuridica pessoaJuridica, CNPJ cnpj)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertFixedLength(cnpj.Codigo, CNPJ.ValorMaxCnpj, ErrorMessage.CNPJTamanhoInvalido),
                AssertionConcern.AssertNotNullOrEmpty(cnpj.Codigo, ErrorMessage.CNPJObrigatorio),
                AssertionConcern.AssertTrue(CNPJ.Validar(cnpj.Codigo), ErrorMessage.CNPJInvalido)
            );
        }

        public static bool DefinirEmailPessoaJuridicaScopeEhValido(this PessoaJuridica pessoaJuridica, Email email)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertLength(email.Endereco, Email.EnderecoMinLength, Email.EnderecoMaxLength, ErrorMessage.EmailTamanhoIncorreto),
                AssertionConcern.AssertTrue(Email.IsValid(email.Endereco), ErrorMessage.EmailInvalido)
            );
        }

        public static bool DefinirTelefonePessoaJuridicaScopeEhValido(this PessoaJuridica pessoaJuridica, Telefone telefone)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(telefone.Numero, ErrorMessage.TelefoneObrigatorio),
                AssertionConcern.AssertLength(telefone.Numero, Telefone.TelefoneMinLength, Telefone.TelefoneMaxLength, ErrorMessage.TelefoneTamanhoIncorreto),
                AssertionConcern.AssertTrue(Telefone.IsValid(telefone.Numero), ErrorMessage.TelefoneInvalido)
            );
        }
    }
}
