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
    public static class EstabelecimentoScopes
    {
        public static bool DefinirDescricaoEstabelecimentoScopeEhValido(this Estabelecimento estabelecimento, string descricao)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(descricao, ErrorMessage.DescricaoObrigatorio),
                AssertionConcern.AssertLength(descricao, Estabelecimento.DescricaoMinLength, Estabelecimento.DescricaoMaxLength, ErrorMessage.DescricaoEstabelecimentoTamanhoInvalido)
            );
        }

        public static bool DefinirLogoEstabelecimentoScopeEhValido(this Estabelecimento estabelecimento, string logo)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(logo, ErrorMessage.LogoObrigatorio)
            );
        }
    }
}
