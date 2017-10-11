using SBP.Domain.Entidades;
using SBP.Domain.SharedKernel.Resources;
using SBP.Domain.SharedKernel.ValueObjects;
using System;

namespace SBP.Domain.Scopes
{
    public static class AtendimentoScopes
    {
        public static bool DefinirClienteScopeEhValido(this Atendimento atendimento, Guid? idCliente)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(idCliente, ErrorMessage.ClienteInvalido)
            );
        }

        public static bool DefinirFuncionarioScopeEhValido(this Atendimento atendimento, Guid? idFuncionario)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(idFuncionario, ErrorMessage.FuncionarioInvalido)
            );
        }

        public static bool DefinirTipoDeServicoScopeEhValido(this Atendimento atendimento, Guid? idTipoDeServico)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(idTipoDeServico, ErrorMessage.TipoDoServicoInvalido)
            );
        }

        public static bool DefinirEstabelecimentoScopeEhValido(this Atendimento atendimento, Guid? idEstabelecimento)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(idEstabelecimento, ErrorMessage.EstabelecimentoObrigatorio)
            );
        }
    }
}
