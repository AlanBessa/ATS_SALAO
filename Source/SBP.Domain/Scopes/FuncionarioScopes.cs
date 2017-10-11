using SBP.Domain.Entidades;
using SBP.Domain.SharedKernel.Resources;
using SBP.Domain.SharedKernel.ValueObjects;
using System;

namespace SBP.Domain.Scopes
{
    public static class FuncionarioScopes
    {
        public static bool DefinirFuncaoScopeEhValido(this Funcionario funcionario, string funcao)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(funcao, ErrorMessage.FuncaoObrigatorio),
                AssertionConcern.AssertLength(funcao, Funcionario.FuncaoMinLength, Funcionario.FuncaoMaxLength, ErrorMessage.FuncaoTamanhoInvalido)
            );
        }

        public static bool DefinirEstabelecimentoScopeEhValido(this Funcionario funcionario, Guid? idEstabelecimento)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(idEstabelecimento, ErrorMessage.EstabelecimentoObrigatorio)
            );
        }

        public static bool DefinirEstabelecimentoScopeEhValido(this Funcionario funcionario, Estabelecimento estabelecimento)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(estabelecimento, ErrorMessage.EstabelecimentoObrigatorio)
            );
        }
    }
}
