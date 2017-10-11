using SBP.Application.Command;
using System;
using System.Collections.Generic;

namespace SBP.Application.Interfaces
{
    public interface IEstabelecimentoApp
    {
        EstabelecimentoCommand Cadastrar(FuncionarioCommand funcionarioCommand);

        EstabelecimentoCommand Atualizar(EstabelecimentoCommand estabelecimentoCommand);

        bool AlterarStatusDeAtivacao(Guid idEstabelecimento, bool estaAtivo);

        EstabelecimentoCommand ObterPorId(Guid id);

        IEnumerable<EstabelecimentoCommand> ObterTodos();

        IEnumerable<EstabelecimentoCommand> ObterTodosPorStatus(bool ativo);
    }
}
