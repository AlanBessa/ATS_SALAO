using DomainValidation.Validation;
using SBP.Domain.Entidades;
using SBP.Domain.Interfaces.Repositories;
using SBP.Domain.SharedKernel.Resources;
using SBP.Domain.Specifications;

namespace SBP.Domain.Validations
{
    public class UsuarioAptaParaEdicaoValidation : Validator<Usuario>
    {
        public UsuarioAptaParaEdicaoValidation(IUsuarioRepository usuarioRepository)
        {
            var emailDuplicado = new UsuarioDevePossuirEmailUnicoSpecification(usuarioRepository);

            base.Add("emailDuplicado", new Rule<Usuario>(emailDuplicado, ErrorMessage.EmailJaExiste));
        }
    }
}
