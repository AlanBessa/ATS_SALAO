using SBP.Domain.Scopes;
using SBP.Domain.SharedKernel.Enum;
using System;

namespace SBP.Domain.Entidades
{
    public class Agenda
    {
        protected Agenda()
        {
        }

        public Agenda(DateTime? dataInicioDoAgendamento, Guid? idCliente, Guid? idFuncionario, 
                      Guid? idTipoDeServico, Guid? idEstabelecimento, Guid? idAgenda)
        {
            IdAgenda = idAgenda == null ? Guid.NewGuid() : idAgenda.Value;

            DefinirDataDoAgendamento(dataInicioDoAgendamento);
            DefinirCliente(idCliente);
            DefinirFuncionario(idFuncionario);
            DefinirTipoDeServico(idTipoDeServico);
            DefinirEstabelecimento(idEstabelecimento);

            Status = EStatus.Agendado;
        }

        #region "Propriedades"

        public Guid IdAgenda { get; private set; }

        public DateTime DataInicioDoAgendamento { get; private set; }

        public DateTime DataFimDoAgendamento { get; private set; }

        public Guid ClienteId { get; private set; }

        public Cliente Cliente { get; private set; }

        public Guid FuncionarioId { get; private set; }

        public Funcionario Funcionario { get; private set; }

        public Guid TipoDeServicoId { get; private set; }

        public TipoDeServico TipoDeServico { get; private set; }

        public Guid EstabelecimentoId { get; private set; }

        public Estabelecimento Estabelecimento { get; private set; }

        public EStatus Status { get; set; }

        #endregion

        #region "Metodos"

        public void DefinirDataDoAgendamento(DateTime? dataInicioDoAgendamento)
        {
            if (this.DefinirDataDoAgendamentoScopeEhValido(dataInicioDoAgendamento))
            {
                DataInicioDoAgendamento = dataInicioDoAgendamento.Value;                
            }                
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

        private void DefinirEstabelecimento(Guid? idEstabelecimento)
        {
            if (this.DefinirEstabelecimentoScopeEhValido(idEstabelecimento))
                EstabelecimentoId = idEstabelecimento.Value;
        }

        public void AlterarStatus(int codStatus)
        {
            Status = (EStatus)codStatus;
        }

        public void CalcularDataFimAgendamentoPeloTipoDeServico(int duracao)
        {
            DataFimDoAgendamento = DataInicioDoAgendamento.AddMinutes(duracao);
        }

        #endregion
    }
}
