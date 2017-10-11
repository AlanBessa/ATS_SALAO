using SBP.Domain.Entidades;
using SBP.Domain.SharedKernel.Resources;
using SBP.Domain.SharedKernel.ValueObjects;
using System;

namespace SBP.Domain.Scopes
{
    public static class ClienteScopes
    {
        public static bool DefinirDataDeNascimentoScopeEhValido(this Cliente cliente, DateTime? dataDeNascimento)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertDateNotNull(dataDeNascimento, ErrorMessage.DataDeNascimentoObrigatorio)
            );
        }
    }
}
