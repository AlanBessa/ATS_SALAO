﻿using DomainValidation.Validation;
using SBP.Domain.Entidades;
using SBP.Domain.Interfaces.Repositories;
using SBP.Domain.SharedKernel.Resources;
using SBP.Domain.Specifications;

namespace SBP.Domain.Validations
{
    public class ClienteAptaParaEdicaoValidation : Validator<Cliente>
    {
        public ClienteAptaParaEdicaoValidation(IClienteRepository clienteRepository)
        {
            var cpfDuplicado = new ClienteDevePossuirCPFUnicoSpecification(clienteRepository);

            base.Add("cpfDuplicado", new Rule<Cliente>(cpfDuplicado, ErrorMessage.CPFJaExiste));
        }
    }
}
