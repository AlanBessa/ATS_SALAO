using System;

namespace SBP.Application.Command
{
    public class EstadoCommand
    {
        public EstadoCommand(string nome, string uf, Guid? idEstado)
        {
            Nome = nome;
            UF = uf;
            IdEstado = idEstado;
        }

        public Guid? IdEstado { get; set; }

        public string Nome { get; set; }

        public string UF { get; set; }
    }
}
