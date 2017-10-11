using SBP.Domain.Scopes;
using SBP.Domain.SharedKernel.Enum;
using System;

namespace SBP.Domain.Entidades
{
    public class HistoricoAgenda
    {
        protected HistoricoAgenda()
        {
        }

        public HistoricoAgenda(DateTime? dataDoAgendamento, Guid? idCliente, Guid? idFuncionario, Guid? idTipoDeServico, Guid? idHistoricoAgenda)
        {
            IdHistoricoAgenda = idHistoricoAgenda == null ? Guid.NewGuid() : idHistoricoAgenda.Value;
            DefinirDataDoAgendamento(dataDoAgendamento);
            DefinirCliente(idCliente);
            DefinirFuncionario(idFuncionario);
            DefinirTipoDeServico(idTipoDeServico);

            DataDeCadastro = DateTime.Now;
        }

        #region "Propriedades"

        public Guid IdHistoricoAgenda { get; private set; }

        public DateTime DataDoAgendamento { get; private set; }

        public DateTime DataDeCadastro { get; private set; }

        public Guid ClienteId { get; private set; }

        public Cliente Cliente { get; private set; }

        public Guid FuncionarioId { get; private set; }

        public Funcionario Funcionario { get; private set; }

        public Guid TipoDeServicoId { get; private set; }

        public TipoDeServico TipoDeServico { get; private set; }

        public EStatus Status { get; private set; }

        #endregion

        #region "Metodos"

        public void DefinirDataDoAgendamento(DateTime? data)
        {
            if (this.DefinirDataDoAgendamentoScopeEhValido(data))
                DataDoAgendamento = data.Value;
        }
        
        public void DefinirCliente(Guid? idCliente)
        {
            if (this.DefinirClienteScopeEhValido(idCliente))
                ClienteId = idCliente.Value;
        }

        public void DefinirFuncionario(Guid? idFuncionario)
        {
            if (this.DefinirFuncionarioScopeEhValido(idFuncionario))
                FuncionarioId = idFuncionario.Value;
        }

        public void DefinirTipoDeServico(Guid? idTipoDeServico)
        {
            if (this.DefinirTipoDeServicoScopeEhValido(idTipoDeServico))
                TipoDeServicoId = idTipoDeServico.Value;
        }
        
        #endregion  
    }
}
