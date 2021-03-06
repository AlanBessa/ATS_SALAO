﻿using DomainValidation.Validation;
using SBP.Domain.Entidades;
using SBP.Domain.Interfaces.Repositories;
using SBP.Domain.SharedKernel.Resources;
using SBP.Domain.Specifications;

namespace SBP.Domain.Validations
{
    public class EstabelecimentoAptoParaEdicaoValidation : Validator<Estabelecimento>
    {
        public EstabelecimentoAptoParaEdicaoValidation(IEstabelecimentoRepository estabelecimentoRepository)
        {
            var cnpjDuplicado = new EstabelecimentoDevePossuirCNPJUnicoSpecification(estabelecimentoRepository);

            base.Add("cnpjDuplicado", new Rule<Estabelecimento>(cnpjDuplicado, ErrorMessage.CNPJJaExiste));
        }
    }
}
