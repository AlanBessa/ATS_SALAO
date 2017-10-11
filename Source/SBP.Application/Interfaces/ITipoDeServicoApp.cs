using SBP.Application.Command;
using System;
using System.Collections.Generic;

namespace SBP.Application.Interfaces
{
    public interface ITipoDeServicoApp
    {
        TipoDeServicoCommand Cadastrar(TipoDeServicoCommand tipoDeServicoCommand);

        TipoDeServicoCommand Atualizar(TipoDeServicoCommand tipoDeServicoCommand);

        TipoDeServicoCommand Remover(Guid id);

        TipoDeServicoCommand ObterPorId(Guid id);

        IEnumerable<TipoDeServicoCommand> ObterTodos();

        IEnumerable<TipoDeServicoCommand> ObterTodosPor(Guid idEstabelecimento);

        IEnumerable<TipoDeServicoCommand> ObterTodos(int skip, int take);
    }
}
