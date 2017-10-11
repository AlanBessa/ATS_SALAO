using DomainValidation.Validation;
using SBP.Domain.Entidades;
using SBP.Domain.Interfaces.Repositories;
using SBP.Domain.SharedKernel.Resources;
using SBP.Domain.Specifications;

namespace SBP.Domain.Validations
{
    public class FuncionarioAptoParaCadastroValidation : Validator<Funcionario>
    {
        public FuncionarioAptoParaCadastroValidation(IFuncionarioRepository funcionarioRepository)
        {
            var cpfDuplicado = new FuncionarioDevePossuirCPFUnicoSpecification(funcionarioRepository);

            base.Add("cpfDuplicado", new Rule<Funcionario>(cpfDuplicado, ErrorMessage.CPFJaExiste));
        }
    }
}
