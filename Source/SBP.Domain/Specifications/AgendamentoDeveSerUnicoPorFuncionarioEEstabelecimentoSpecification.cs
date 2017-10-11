using DomainValidation.Interfaces.Specification;
using SBP.Domain.Entidades;
using SBP.Domain.Interfaces.Repositories;

namespace SBP.Domain.Specifications
{
    public class AgendamentoDeveSerUnicoPorFuncionarioEEstabelecimentoSpecification : ISpecification<Agenda>
    {
        private readonly IAgendaRepository _agendaRepository;

        public AgendamentoDeveSerUnicoPorFuncionarioEEstabelecimentoSpecification(IAgendaRepository agendaRepository)
        {
            _agendaRepository = agendaRepository;
        }

        public bool IsSatisfiedBy(Agenda agenda)
        {
            var ag = _agendaRepository.ObterPorFiltro(agenda.DataInicioDoAgendamento, agenda.FuncionarioId, agenda.EstabelecimentoId);

            return (ag == null || (ag != null && ag.IdAgenda == agenda.IdAgenda));
        }
    }
}
