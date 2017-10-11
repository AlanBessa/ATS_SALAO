using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP.Application.Command
{
    public class ContatoCommand
    {
        public ContatoCommand(string nome, string email, string celular, string mensagem)
        {
            Nome = nome;
            Email = email;
            Celular = celular;
            Mensagem = mensagem;
        }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Celular { get; set; }

        public string Mensagem { get; set; }
    }
}
