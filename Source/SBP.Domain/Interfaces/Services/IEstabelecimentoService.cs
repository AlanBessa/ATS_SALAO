using SBP.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace SBP.Domain.Interfaces.Services
{
    public interface IEstabelecimentoService
    {
        Estabelecimento Adicionar(Estabelecimento estabelecimento);

        Estabelecimento Atualizar(Estabelecimento estabelecimento);

        Estabelecimento ObterPorId(Guid id);
        
        IEnumerable<Estabelecimento> ObterTodos();

        IEnumerable<Estabelecimento> ObterTodosPorStatus(bool ativo);
    }
}
