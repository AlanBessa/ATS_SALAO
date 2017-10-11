using SBP.Application.Command;
using SBP.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP.Application.Adapters
{
    public class EstadoAdapter
    {
        public static Estado ToDomainModel(EstadoCommand estadoCommand)
        {
            if (estadoCommand == null) return null;

            var estado = new Estado(
                estadoCommand.UF,
                estadoCommand.Nome,
                estadoCommand.IdEstado);
            
            return estado;
        }

        public static EstadoCommand ToModelDomain(Estado estado)
        {
            if (estado == null) return null;

            var estadoCommand = new EstadoCommand(
                estado.Nome,
                estado.UF,
                estado.IdEstado);
            
            return estadoCommand;
        }
    }
}
