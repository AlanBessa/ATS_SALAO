using System;

namespace SBP.Application.Command
{
    public class CidadeCommand
    {
        public CidadeCommand(string nome, Guid? idCidade, Guid? estadoId)
        {
            Nome = nome;
            IdCidade = idCidade;
            EstadoId = estadoId;
        }

        public Guid? IdCidade { get; set; }

        public Guid? EstadoId { get; set; }

        public EstadoCommand Estado { get; set; }

        public string Nome { get; set; }
    }
}
