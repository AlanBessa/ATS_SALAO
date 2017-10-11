using SBP.Domain.Scopes;
using SBP.Domain.SharedKernel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP.Domain.Entidades
{
    public class Estabelecimento : PessoaJuridica
    {
        private IList<Funcionario> _funcionarios;

        #region "Constantes"

        public const int DescricaoMinLength = 6;
        public const int DescricaoMaxLength = 500;

        #endregion

        protected Estabelecimento()
        {
        }

        public Estabelecimento(string razaoSocial, string nomeFantasia, string email, string cnpj, string telefone, 
                               string descricao, string logo, Guid? idPessoaJuridica)
            : base(razaoSocial, nomeFantasia, email, cnpj, telefone, idPessoaJuridica)
        {
            EstaAtivo = true;
            DataDeCadastro = DateTime.Now;

            DefinirDescricao(descricao);
            DefinirLogo(logo);

            ListaDeFuncionarios = new List<Funcionario>();
            ListaDeTiposDeServico = new List<TipoDeServico>();
            ListaDeAgendamento = new List<Agenda>();
            ListaDeAtendimentos = new List<Atendimento>();
        }

        #region "Propriedades"

        public byte[] Logo { get; private set; }

        public bool EstaAtivo { get; private set; }

        public string Descricao { get; private set; }

        public DateTime DataDeCadastro { get; private set; }

        public DateTime? DataDeAtualizacao { get; private set; }

        public ICollection<Funcionario> ListaDeFuncionarios
        {
            get { return _funcionarios; }
            private set { _funcionarios = new List<Funcionario>(value); }
        }

        public ICollection<TipoDeServico> ListaDeTiposDeServico { get; set; }

        public ICollection<Agenda> ListaDeAgendamento { get; set; }

        public ICollection<Atendimento> ListaDeAtendimentos { get; set; }

        #endregion

        #region "Metodos"

        public void DefinirDescricao(string descricao)
        {
            if (!this.DefinirDescricaoEstabelecimentoScopeEhValido(descricao))
                return;

            Descricao = descricao;
        }

        public void AlterarStatusDeAtivacao(bool estaAtivo)
        {
            DataDeAtualizacao = DateTime.Now;
            EstaAtivo = estaAtivo;
        }

        public void DefinirLogo(string logo)
        {
            if (!this.DefinirLogoEstabelecimentoScopeEhValido(logo))
                return;

            Logo = ImageHelper.ConverterParaBytes(logo);
        }

        public void AtualizarDados(string razaoSocial, string nomeFantasia, string email, string cnpj, string telefone,
                                   string descricao, string logo)
        {
            DataDeAtualizacao = DateTime.Now;
            DefinirRazaoSocial(razaoSocial);
            DefinirNomeFantasia(nomeFantasia);
            DefinirCNPJ(cnpj);
            DefinirEmail(email);
            DefinirTelefone(telefone);
            DefinirDescricao(descricao);
            DefinirLogo(logo);
        }

        public void AdicionarFuncionario(Funcionario funcionario)
        {
            _funcionarios.Add(funcionario);
        }

        public void AnularListaDeFuncionario()
        {
            _funcionarios = new List<Funcionario>();
        }

        #endregion
    }
}
