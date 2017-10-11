using SBP.Domain.Scopes;
using System;
using System.Collections.Generic;

namespace SBP.Domain.Entidades
{
    public class Funcionario : Pessoa
    {
        #region "Constantes"

        public const int FuncaoMinLength = 3;
        public const int FuncaoMaxLength = 100;

        #endregion

        protected Funcionario()
        {
        }

        public Funcionario(string nome, string cpf, string celular, Guid? idPessoa, string funcao, Guid? idEstabelecimento, string imagem = "")
            : base(nome, cpf, celular, idPessoa, imagem)
        {
            EstaAtivo = true;
            DataDeCadastro = DateTime.Now;
            DefinirFuncao(funcao);
            DefinirEstabelecimento(idEstabelecimento);

            ListaDeAgendamentos = new List<Agenda>();
            ListaDeAtendimentos = new List<Atendimento>();
            ListaDeHistoricoDeAgendamentos = new List<HistoricoAgenda>();
        }

        #region "Propriedades"

        public bool EstaAtivo { get; private set; }

        public string Funcao { get; private set; }        

        public DateTime DataDeCadastro { get; private set; }

        public DateTime? DataDeAtualizacao { get; private set; }

        public Guid EstabelecimentoId { get; private set; }

        public Estabelecimento Estabelecimento { get; private set; }

        public ICollection<Agenda> ListaDeAgendamentos { get; set; }

        public ICollection<HistoricoAgenda> ListaDeHistoricoDeAgendamentos { get; set; }

        public ICollection<Atendimento> ListaDeAtendimentos { get; set; }

        #endregion

        #region "Metodos"

        public void AlterarStatusDeAtivacao(bool estaAtivo)
        {
            DataDeAtualizacao = DateTime.Now;
            EstaAtivo = estaAtivo;
        }

        public void DefinirFuncao(string funcao)
        {
            if (this.DefinirFuncaoScopeEhValido(funcao))
                Funcao = funcao;
        }

        public void DefinirEstabelecimento(Guid? idEstabelecimento)
        {
            if (this.DefinirEstabelecimentoScopeEhValido(idEstabelecimento))
                EstabelecimentoId = idEstabelecimento.Value;
        }

        public void DefinirEstabelecimento(Estabelecimento estabelecimento)
        {
            if (this.DefinirEstabelecimentoScopeEhValido(estabelecimento))
                Estabelecimento = estabelecimento;
        }

        public void AnularEstabelecimento()
        {
            Estabelecimento = null;
        }

        public void AtualizarDados(string nome, string cpf, string celular, string email, string funcao, string imagem)
        {
            DataDeAtualizacao = DateTime.Now;
            DefinirNome(nome);
            DefinirCPF(cpf);
            DefinirCelular(celular);
            DefinirEmail(email);
            DefinirImagem(imagem);
            DefinirFuncao(funcao);
        }

        #endregion
    }
}
