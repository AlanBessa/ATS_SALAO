using SBP.Domain.Scopes;
using System;
using System.Collections.Generic;

namespace SBP.Domain.Entidades
{
    public class TipoDeServico
    {
        #region "Constantes"

        public const int DescricaoMinLength = 0;
        public const int DescricaoMaxLength = 500;

        public const int TituloMinLength = 3;
        public const int TituloMaxLength = 50;

        #endregion

        protected TipoDeServico()
        {
        }

        public TipoDeServico(string titulo, string descricao, decimal preco, int tempoGastoEmMinutos, Guid? idTipoDeServico, Guid? idEstabelecimento)
        {
            IdTipoDeServico = idTipoDeServico == null ? Guid.NewGuid() : idTipoDeServico.Value;

            DefinirTitulo(titulo);
            DefinirDescricao(descricao);
            DefinirPreco(preco);
            DefinirTempo(tempoGastoEmMinutos);
            DefinirEstabelecimento(idEstabelecimento);
            DataDeCadastro = DateTime.Now;
            DataDeAtualizacao = null;

            ListaDeAgendamentos = new List<Agenda>();
            ListaDeAtendimentos = new List<Atendimento>();
            ListaDeHistoricoDeAgendamentos = new List<HistoricoAgenda>();
        }

        #region "Propriedades"

        public Guid IdTipoDeServico { get; private set; }

        public string Titulo { get; private set; }

        public string Descricao { get; private set; }

        public DateTime DataDeCadastro { get; private set; }

        public DateTime? DataDeAtualizacao { get; set; }

        public decimal Preco { get; private set; }

        public int TempoGastoEmMinutos { get; private set; }

        public Guid EstabelecimentoId { get; private set; }

        public Estabelecimento Estabelecimento { get; private set; }

        public ICollection<Agenda> ListaDeAgendamentos { get; set; }

        public ICollection<HistoricoAgenda> ListaDeHistoricoDeAgendamentos { get; set; }

        public ICollection<Atendimento> ListaDeAtendimentos { get; set; }

        #endregion

        #region "Métodos"

        private void DefinirTitulo(string titulo)
        {
            if (this.DefinirTituloScopeEhValido(titulo))
                Titulo = titulo;
        }

        private void DefinirDescricao(string descricao)
        {
            if (this.DefinirDescricaoScopeEhValido(descricao))
                Descricao = descricao;
        }

        private void DefinirPreco(decimal preco)
        {
            Preco = preco;
        }

        private void DefinirTempo(int tempo)
        {
            TempoGastoEmMinutos = tempo;
        }

        private void DefinirEstabelecimento(Guid? idEstabelecimento)
        {
            if (this.DefinirEstabelecimentoScopeEhValido(idEstabelecimento))
                EstabelecimentoId = idEstabelecimento.Value;
        }

        public void AtualizarDados(string titulo, string descricao, decimal preco, int tempoGastoEmMinutos)
        {
            DefinirTitulo(titulo);
            DefinirDescricao(descricao);
            DefinirPreco(preco);
            DefinirTempo(tempoGastoEmMinutos);
            DataDeAtualizacao = DateTime.Now;
        }

        #endregion
    }
}
