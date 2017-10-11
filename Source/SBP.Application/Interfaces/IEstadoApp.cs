using SBP.Application.Command;
using System.Collections.Generic;

namespace SBP.Application.Interfaces
{
    public interface IEstadoApp
    {
        IEnumerable<EstadoCommand> ObterTodos();
    }
}
