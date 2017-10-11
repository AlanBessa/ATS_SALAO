using System;

namespace SBP.Application.Command
{
    public class EstabelecimentoCommand
    {
        public EstabelecimentoCommand(string razaoSocial, string nomeFantasia, string email, string cnpj, string telefone, 
                                      string logo, string descricao)
        {
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            Email = email;
            CNPJ = cnpj;
            Telefone = telefone;
            Logo = logo;
            Descricao = descricao;
        }

        public Guid? IdPessoaJuridica { get; set; }

        public string RazaoSocial { get; set; }

        public string NomeFantasia { get; set; }

        public string Email { get; set; }

        public string CNPJ { get; set; }

        public string Telefone { get; set; }

        public string Logo { get; set; }

        public bool EstaAtivo { get; set; }

        public string Descricao { get; set; }

        public EnderecoJuridicoCommand EnderecoJuridico { get; set; }

        public FuncionarioCommand PrimeiroFuncionario  { get; set; }
    }
}
