using SBP.Domain.Entidades;
using SBP.Domain.SharedKernel.Resources;
using SBP.Domain.SharedKernel.ValueObjects;
using System;

namespace SBP.Domain.Scopes
{
    public static class EnderecoScopes
    {
        public static bool DefinirCEPScopeEhValido(this Endereco endereco, string cep)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(cep, ErrorMessage.CepObrigatorio),
                AssertionConcern.AssertFixedLength(cep, CEP.CepMaxLength, ErrorMessage.CepTamanhoInvalido)
            );
        }

        public static bool DefinirLogradouroScopeEhValido(this Endereco endereco, string logradouro)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(logradouro, ErrorMessage.LogradouroObrigatorio)
            );
        }

        public static bool DefinirNumeroScopeEhValido(this Endereco endereco, string numero)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(numero, ErrorMessage.NumeroObrigatorio)
            );
        }

        public static bool DefinirBairroScopeEhValido(this Endereco endereco, string bairro)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(bairro, ErrorMessage.BairroObrigatorio)
            );
        }

        public static bool DefinirCidadeScopeEhValido(this Endereco endereco, Guid cidadeId)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertTrue(cidadeId != Guid.Empty, ErrorMessage.CidadeObrigatorio)
            );
        }

        public static bool DefinirCidadeScopeEhValido(this Endereco endereco, Cidade cidade)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(cidade, ErrorMessage.CidadeObrigatorio)
            );
        }

        public static bool DefinirEstadoScopeEhValido(this Endereco endereco, Guid estadoId)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertTrue(estadoId != Guid.Empty, ErrorMessage.EstadoInvalido)
            );
        }

        public static bool DefinirEstadoScopeEhValido(this Endereco endereco, Estado estado)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(estado, ErrorMessage.EstadoInvalido)
            );
        }
    }
}
