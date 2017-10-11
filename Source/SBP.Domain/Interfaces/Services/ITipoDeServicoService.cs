using SBP.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace SBP.Domain.Interfaces.Services
{
    public interface ITipoDeServicoService
    {
        TipoDeServico Adicionar(TipoDeServico tipoDeServico);

        TipoDeServico Atualizar(TipoDeServico tipoDeServico);

        TipoDeServico Remover(Guid id);

        TipoDeServico ObterPorId(Guid id);

        IEnumerable<TipoDeServico> ObterTodos();

        IEnumerable<TipoDeServico> ObterTodos(int skip, int take);

        IEnumerable<TipoDeServico> ObterTodosPor(Guid idEstabelecimento);
    }
}
