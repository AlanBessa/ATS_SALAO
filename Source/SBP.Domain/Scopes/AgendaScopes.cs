using SBP.Domain.Entidades;
using SBP.Domain.SharedKernel.Resources;
using SBP.Domain.SharedKernel.ValueObjects;
using System;

namespace SBP.Domain.Scopes
{
    public static class AgendaScopes
    {
        public static bool DefinirDataDoAgendamentoScopeEhValido(this Agenda agenda, DateTime? dataInicioDoAgendamento)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertDateNotNull(dataInicioDoAgendamento, ErrorMessage.DataDeAgendamentoInvalido)
            );
        }

        public static bool DefinirClienteScopeEhValido(this Agenda agenda, Guid? idCliente)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(idCliente, ErrorMessage.ClienteInvalido)
            );
        }

        public static bool DefinirFuncionarioScopeEhValido(this Agenda agenda, Guid? idFuncionario)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(idFuncionario, ErrorMessage.FuncionarioInvalido)
            );
        }

        public static bool DefinirTipoDeServicoScopeEhValido(this Agenda agenda, Guid? idTipoDeServico)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(idTipoDeServico, ErrorMessage.TipoDoServicoInvalido)
            );
        }

        public static bool DefinirEstabelecimentoScopeEhValido(this Agenda agenda, Guid? idEstabelecimento)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(idEstabelecimento, ErrorMessage.EstabelecimentoObrigatorio)
            );
        }
    }
}
