using DomainValidation.Interfaces.Specification;
using SBP.Domain.Entidades;
using SBP.Domain.Interfaces.Repositories;

namespace SBP.Domain.Specifications
{
    public class FuncionarioDevePossuirCPFUnicoSpecification : ISpecification<Funcionario>
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioDevePossuirCPFUnicoSpecification(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public bool IsSatisfiedBy(Funcionario funcionario)
        {
            var func = _funcionarioRepository.ObterPorCPF(funcionario.CPF.Codigo);

            return (func == null || (func != null && func.IdPessoa == funcionario.IdPessoa));
        }
    }
}
