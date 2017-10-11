using System;

namespace SBP.Application.Command
{
    public class ClienteCommand
    {
        public ClienteCommand(string nome, string cpf, string celular, string email, DateTime? dataDeNascimento, string imagem)
        {
            Nome = nome;
            CPF = cpf;
            Celular = celular;
            Email = email;
            DataDeNascimento = dataDeNascimento;
            Imagem = imagem;
        }

        public Guid? IdPessoa { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public string Celular { get; set; }

        public string Email { get; set; }

        public DateTime? DataDeNascimento { get; set; }

        public string Imagem { get; set; }

        public EnderecoCommand Endereco { get; set; }
    }
}
