using SBP.Application.Command;
using System;
using System.Collections.Generic;

namespace SBP.Application.Interfaces
{
    public interface ICidadeApp
    {
        IEnumerable<CidadeCommand> ObterTodos(Guid idEstado);
    }
}
