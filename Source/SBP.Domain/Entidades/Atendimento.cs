using SBP.Domain.Scopes;
using SBP.Domain.SharedKernel.Enum;
using System;

namespace SBP.Domain.Entidades
{
    public class Atendimento
    {
        protected Atendimento()
        {
        }

        public Atendimento(Guid? idCliente, Guid? idFuncionario, Guid? idTipoDeServico, Guid? idEstabelecimento, Guid? idAtendimento)
        {
            IdAtendimento = idAtendimento == null ? Guid.NewGuid() : idAtendimento.Value;
            
            DefinirCliente(idCliente);
            DefinirFuncionario(idFuncionario);
            DefinirTipoDeServico(idTipoDeServico);
            DefinirEstabelecimento(idEstabelecimento);

            Status = EStatus.EmAtendimento;
            DataHoraInicio = DateTime.Now;
        }

        #region "Propriedades"

        public Guid IdAtendimento { get; private set; }

        public DateTime DataHoraInicio { get; private set; }

        public DateTime? DataHoraFim { get; private set; }

        public string Observacao { get; set; }

        public EStatusPagamento StatusPagamento { get; set; }

        public decimal ValorPago { get; set; }

        public EStatus Status { get; private set; }

        public Guid ClienteId { get; private set; }

        public Cliente Cliente { get; private set; }

        public Guid FuncionarioId { get; private set; }

        public Funcionario Funcionario { get; private set; }

        public Guid TipoDeServicoId { get; private set; }

        public TipoDeServico TipoDeServico { get; private set; }

        public Guid EstabelecimentoId { get; private set; }

        public Estabelecimento Estabelecimento { get; private set; }

        #endregion

        #region "Metodos"

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

        #endregion
    }
}
