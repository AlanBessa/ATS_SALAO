using SBP.Domain.Entidades;
using SBP.Domain.SharedKernel.Resources;
using SBP.Domain.SharedKernel.ValueObjects;
using System;

namespace SBP.Domain.Scopes
{
    public static class PessoaScopes
    {
        public static bool DefinirNomeScopeEhValido(this Pessoa pessoa, string nome)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(nome, ErrorMessage.NomeObrigatorio),
                AssertionConcern.AssertLength(nome, Pessoa.NomeMinLength, Pessoa.NomeMaxLength, ErrorMessage.NomeTamanhoInvalido)
            );
        }

        public static bool DefinirCPFScopeEhValido(this Pessoa pessoa, CPF cpf)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(cpf.Codigo, ErrorMessage.CPFObrigatorio),
                AssertionConcern.AssertFixedLength(cpf.Codigo, CPF.ValorMaxCpf, ErrorMessage.CPFTamanhoInvalido),
                AssertionConcern.AssertTrue(CPF.Validar(cpf.Codigo), ErrorMessage.CPFInvalido)
            );
        }

        public static bool DefinirEmailScopeEhValido(this Pessoa pessoa, Email email)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(email.Endereco, ErrorMessage.EmailObrigatorio),
                AssertionConcern.AssertLength(email.Endereco, Email.EnderecoMinLength, Email.EnderecoMaxLength, ErrorMessage.EmailTamanhoIncorreto),                
                AssertionConcern.AssertTrue(Email.IsValid(email.Endereco), ErrorMessage.EmailInvalido)
            );
        }

        public static bool DefinirCelularScopeEhValido(this Pessoa pessoa, Telefone telefone)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(telefone.Numero, ErrorMessage.TelefoneObrigatorio),
                AssertionConcern.AssertLength(telefone.Numero, Telefone.TelefoneMinLength, Telefone.TelefoneMaxLength, ErrorMessage.TelefoneTamanhoIncorreto),                
                AssertionConcern.AssertTrue(Telefone.IsValid(telefone.Numero), ErrorMessage.TelefoneInvalido)
            );
        }

        public static bool DefinirUsuarioScopeEhValido(this Pessoa pessoa, Guid? idUsuario)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(idUsuario, ErrorMessage.UsuarioObrigatorio)
            );
        }
    }
}
