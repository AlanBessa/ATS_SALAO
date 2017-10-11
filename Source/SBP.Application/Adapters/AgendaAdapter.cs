using SBP.Application.Command;
using SBP.Domain.Entidades;

namespace SBP.Application.Adapters
{
    public class AgendaAdapter
    {
        public static Agenda ToDomainModel(AgendaCommand agendaCommand)
        {
            var agenda = new Agenda(
                agendaCommand.DataInicioDoAgendamento,
                agendaCommand.ClienteId,
                agendaCommand.FuncionarioId,
                agendaCommand.TipoDeServicoId,
                agendaCommand.EstabelecimentoId,
                agendaCommand.IdAgenda);            

            return agenda;
        }

        public static AgendaCommand ToModelDomain(Agenda agenda)
        {
            if (agenda == null) return null;

            var agendaCommand = new AgendaCommand(
                agenda.DataInicioDoAgendamento,
                agenda.ClienteId,
                agenda.FuncionarioId,
                agenda.TipoDeServicoId,
                agenda.EstabelecimentoId);

            agendaCommand.IdAgenda = agenda.IdAgenda;
            agendaCommand.Status = agenda.Status;
            agendaCommand.DataFimDoAgendamento = agenda.DataFimDoAgendamento;
            agendaCommand.Cliente = ClienteAdapter.ToModelDomain(agenda.Cliente);
            agendaCommand.Funcionario = FuncionarioAdapter.ToModelDomain(agenda.Funcionario);
            
            return agendaCommand;
        }
    }
}
