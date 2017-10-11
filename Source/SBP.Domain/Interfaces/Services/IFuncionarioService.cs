using SBP.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace SBP.Domain.Interfaces.Services
{
    public interface IFuncionarioService
    {
        Funcionario Adicionar(Funcionario funcionario);

        Funcionario Atualizar(Funcionario funcionario);

        void AlterarStatusDeAtivacao(Guid idFuncionario, bool estaAtivo);

        Funcionario ObterPorId(Guid id);

        IEnumerable<Funcionario> ObterTodos();

        IEnumerable<Funcionario> ObterTodosPorEstabelecimentoEhStatus(Guid idEstabelecimento, bool ativo);
    }
}
