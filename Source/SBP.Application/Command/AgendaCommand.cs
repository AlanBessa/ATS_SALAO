using SBP.Domain.SharedKernel.Enum;
using System;

namespace SBP.Application.Command
{
    public class AgendaCommand
    {
        public AgendaCommand(DateTime? dataInicioDoAgendamento, Guid? idCliente, Guid? idFuncionario, Guid? idTipoDeServico, 
                             Guid? idEstabelecimento)
        {
            DataInicioDoAgendamento = dataInicioDoAgendamento;
            ClienteId = idCliente;
            FuncionarioId = idFuncionario;
            TipoDeServicoId = idTipoDeServico;
            EstabelecimentoId = idEstabelecimento;

            type = Status == EStatus.Cancelado ? "inverse" : "info";
            editable = false;
            deletable = false;
            draggable = false;
            resizable = false;
            incrementsBadgeTotal = true;
            recursOn = "year";
            cssClass = "a-css-class-name";
            allDay = false;
        }

        public Guid? IdAgenda { get; set; }

        public DateTime? DataInicioDoAgendamento { get; set; }

        public DateTime? DataFimDoAgendamento { get; set; }

        public Guid? ClienteId { get; set; }

        public ClienteCommand Cliente { get; set; }

        public Guid? FuncionarioId { get; set; }

        public FuncionarioCommand Funcionario { get; set; }

        public Guid? TipoDeServicoId { get; set; }

        public TipoDeServicoCommand TipoDeServico { get; set; }

        public Guid? EstabelecimentoId { get; set; }

        public EstabelecimentoCommand Estabelecimento { get; set; }

        public EStatus Status { get; set; }

        public string title {
            get
            {
                return Cliente.Nome;
            }
        }

        public string type { get; set; }

        public DateTime startsAt
        {
            get
            {
                return DataInicioDoAgendamento.Value;
            }
        }

        public DateTime endsAt
        {
            get
            {
                return DataFimDoAgendamento.Value;
            }
        }
        
        public bool editable { get; set; }

        public bool deletable { get; set; }

        public bool draggable { get; set; }

        public bool resizable { get; set; }

        public bool incrementsBadgeTotal { get; set; }

        public string recursOn { get; set; }

        public string cssClass { get; set; }

        public bool allDay { get; set; }
    }
}
