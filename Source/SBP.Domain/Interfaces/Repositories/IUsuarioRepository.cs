using SBP.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SBP.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        void Adicionar(Usuario usuario);

        void Atualizar(Usuario usuario);

        void Remover(Guid id);

        Usuario ObterPorId(Guid id);

        Usuario ObterPorEmail(string email);

        Usuario ObterPorPessoaId(Guid idPessoa);

        IEnumerable<Usuario> ObterTodos();

        IEnumerable<Usuario> Buscar(Expression<Func<Usuario, bool>> predicate);
    }
}
