using DomainValidation.Validation;
using SBP.Domain.Entidades;
using SBP.Domain.Interfaces.Repositories;
using SBP.Domain.SharedKernel.Resources;
using SBP.Domain.Specifications;

namespace SBP.Domain.Validations
{
    public class FuncionarioAptaParaEdicaoValidation : Validator<Funcionario>
    {
        public FuncionarioAptaParaEdicaoValidation(IFuncionarioRepository funcionarioRepository)
        {
            var cpfDuplicado = new FuncionarioDevePossuirCPFUnicoSpecification(funcionarioRepository);

            base.Add("cpfDuplicado", new Rule<Funcionario>(cpfDuplicado, ErrorMessage.CPFJaExiste));
        }
    }
}
