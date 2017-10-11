using SBP.Domain.Entidades;
using SBP.Domain.SharedKernel.Resources;
using SBP.Domain.SharedKernel.ValueObjects;
using System;

namespace SBP.Domain.Scopes
{
    public static class HistoricoAgendaScopes
    {
        public static bool DefinirDataDoAgendamentoScopeEhValido(this HistoricoAgenda historicoAgenda, DateTime? dataDeAgendamento)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertDateNotNull(dataDeAgendamento, ErrorMessage.DataDeAgendamentoInvalido)
            );
        }

        public static bool DefinirClienteScopeEhValido(this HistoricoAgenda historicoAgenda, Guid? idCliente)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(idCliente, ErrorMessage.ClienteInvalido)
            );
        }

        public static bool DefinirFuncionarioScopeEhValido(this HistoricoAgenda historicoAgenda, Guid? idFuncionario)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(idFuncionario, ErrorMessage.FuncionarioInvalido)
            );
        }

        public static bool DefinirTipoDeServicoScopeEhValido(this HistoricoAgenda historicoAgenda, Guid? idTipoDeServico)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(idTipoDeServico, ErrorMessage.TipoDoServicoInvalido)
            );
        }
    }
}
