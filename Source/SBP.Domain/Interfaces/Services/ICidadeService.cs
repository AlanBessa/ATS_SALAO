using SBP.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace SBP.Domain.Interfaces.Services
{
    public interface ICidadeService
    {
        IEnumerable<Cidade> ObterTodos(Guid idEstado);
    }
}
