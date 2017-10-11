using SBP.Domain.SharedKernel.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP.Application.Command
{
    public class AtendimentoCommand
    {
        public AtendimentoCommand(Guid? idCliente, Guid? idFuncionario, Guid? idTipoDeServico, Guid? idEstabelecimento, Guid? idAtendimento)
        {
            ClienteId = idCliente;
            FuncionarioId = idFuncionario;
            TipoDeServicoId = idTipoDeServico;
            EstabelecimentoId = idEstabelecimento;
            IdAtendimento = idAtendimento;
        }

        public Guid? IdAtendimento { get; set; }

        public DateTime DataHoraInicio { get; set; }

        public DateTime? DataHoraFim { get; set; }

        public string Observacao { get; set; }

        public EStatusPagamento StatusPagamento { get; set; }

        public decimal ValorPago { get; set; }

        public EStatus Status { get; set; }

        public Guid? ClienteId { get; set; }

        public ClienteCommand Cliente { get; set; }

        public Guid? FuncionarioId { get; set; }

        public FuncionarioCommand Funcionario { get; set; }

        public Guid? TipoDeServicoId { get; set; }

        public TipoDeServicoCommand TipoDeServico { get; set; }

        public Guid? EstabelecimentoId { get; set; }

        public EstabelecimentoCommand Estabelecimento { get; set; }
    }
}
