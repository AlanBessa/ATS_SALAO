using SBP.Domain.Entidades;
using SBP.Domain.SharedKernel.Resources;
using SBP.Domain.SharedKernel.ValueObjects;
using System;

namespace SBP.Domain.Scopes
{
    public static class TipoDeServicoScopes
    {
        public static bool DefinirTituloScopeEhValido(this TipoDeServico tipoDeServico, string titulo)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(titulo, ErrorMessage.TituloTipoDeServicoObrigatorio),
                AssertionConcern.AssertLength(titulo, TipoDeServico.TituloMinLength, TipoDeServico.TituloMaxLength, ErrorMessage.TituloTipoDeServicoTamanhoIncorreto)
            );
        }

        public static bool DefinirDescricaoScopeEhValido(this TipoDeServico tipoDeServico, string descricao)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertLength(descricao, TipoDeServico.DescricaoMinLength, TipoDeServico.DescricaoMaxLength, ErrorMessage.DescricaoTipoDeServicoTamanhoInvalido)
            );
        }

        public static bool DefinirEstabelecimentoScopeEhValido(this TipoDeServico tipoDeServico, Guid? idEstabelecimento)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(idEstabelecimento, ErrorMessage.EstabelecimentoObrigatorio)
            );
        }
    }
}
