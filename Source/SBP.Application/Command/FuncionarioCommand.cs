using System;

namespace SBP.Application.Command
{
    public class FuncionarioCommand
    {
        public FuncionarioCommand(string nome, string cpf, string celular, string email, string funcao, Guid? idEstabelecimento, string imagem)
        {
            Nome = nome;
            CPF = cpf;
            Celular = celular;
            Email = email;
            Funcao = funcao;
            Imagem = imagem;
            EstabelecimentoId = idEstabelecimento;
        }

        public Guid? IdPessoa { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public string Celular { get; set; }

        public string Email { get; set; }

        public string Imagem { get; set; }

        public string Funcao { get; set; }

        public bool EstaAtivo { get; set; }

        public EnderecoCommand Endereco { get; set; }

        public Guid? EstabelecimentoId { get; set; }

        public EstabelecimentoCommand Estabelecimento { get; set; }
        
        public UsuarioCommand Usuario { get; set; }
    }
}
