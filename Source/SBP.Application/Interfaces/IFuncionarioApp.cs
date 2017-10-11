using SBP.Application.Command;
using System;
using System.Collections.Generic;

namespace SBP.Application.Interfaces
{
    public interface IFuncionarioApp
    {
        FuncionarioCommand Cadastrar(FuncionarioCommand funcionarioCommand);

        FuncionarioCommand Atualizar(FuncionarioCommand funcionarioCommand);

        bool AlterarStatusDeAtivacao(Guid idFuncionario, bool estaAtivo);

        bool AlterarStatusDeAtivacaoDoFuncionario(Guid idFuncionario, bool estaAtivo);

        FuncionarioCommand ObterPorId(Guid id);

        IEnumerable<FuncionarioCommand> ObterTodos();

        IEnumerable<FuncionarioCommand> ObterTodosPorEstabelecimentoEhStatus(Guid idEstabelecimento, bool ativo);
    }
}
