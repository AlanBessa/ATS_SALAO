using SBP.Domain.Scopes;
using System;
using System.Collections.Generic;

namespace SBP.Domain.Entidades
{
    public class Cliente : Pessoa
    {
        protected Cliente()
        {
        }

        public Cliente(DateTime? dataDeNascimento, string nome, string cpf, string celular, Guid? idPessoa, string imagem = "")
            : base(nome, cpf, celular, idPessoa, imagem)
        {
            DefinirDataDeNascimento(dataDeNascimento);

            DataDeCadastro = DateTime.Now;

            ListaDeAgendamentos = new List<Agenda>();
            ListaDeHistoricoDeAgendamentos = new List<HistoricoAgenda>();
            ListaDeAtendimentos = new List<Atendimento>();
        }

        #region "Propriedades"

        public DateTime DataDeNascimento { get; private set; }

        public DateTime DataDeCadastro { get; private set; }

        public DateTime? DataDeAtualizacao { get; set; }

        public ICollection<Agenda> ListaDeAgendamentos { get; set; }

        public ICollection<HistoricoAgenda> ListaDeHistoricoDeAgendamentos { get; set; }

        public ICollection<Atendimento> ListaDeAtendimentos { get; set; }

        #endregion

        #region "Metodos"

        public void DefinirDataDeNascimento(DateTime? data)
        {
            if (this.DefinirDataDeNascimentoScopeEhValido(data))
                DataDeNascimento = data.Value;
        }

        public void AtualizarDados(string nome, string cpf, string celular, string email, DateTime dataDeNascimento)
        {
            DataDeAtualizacao = DateTime.Now;
            DefinirNome(nome);
            DefinirCPF(cpf);
            DefinirCelular(celular);
            DefinirEmail(email);
            DefinirDataDeNascimento(dataDeNascimento);
        }

        #endregion
    }
}
