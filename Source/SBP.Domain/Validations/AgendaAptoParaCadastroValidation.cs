using DomainValidation.Validation;
using SBP.Domain.Entidades;
using SBP.Domain.Interfaces.Repositories;
using SBP.Domain.SharedKernel.Resources;
using SBP.Domain.Specifications;

namespace SBP.Domain.Validations
{
    public class AgendaAptoParaCadastroValidation : Validator<Agenda>
    {
        public AgendaAptoParaCadastroValidation(IAgendaRepository agendaRepository)
        {
            var agendamentoDuplicado = new AgendamentoDeveSerUnicoPorFuncionarioEEstabelecimentoSpecification(agendaRepository);

            base.Add("agendamentoDuplicado", new Rule<Agenda>(agendamentoDuplicado, ErrorMessage.AgendamentoJaExiste));
        }
    }
}
