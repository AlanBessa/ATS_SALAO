using SBP.Domain.Entidades;
using SBP.Domain.Interfaces.Repositories;
using SBP.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SBP.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SalaoAgendadorContext _context;

        public UsuarioRepository(SalaoAgendadorContext context)
        {
            _context = context;
        }

        public void Adicionar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
        }

        public void Atualizar(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
        }

        public IEnumerable<Usuario> Buscar(Expression<Func<Usuario, bool>> predicate)
        {
            return _context.Usuarios.Include("Pessoa").Where(predicate);
        }
        
        public Usuario ObterPorId(Guid id)
        {
            return _context.Usuarios.Find(id);
        }

        public Usuario ObterPorEmail(string email)
        {
            return Buscar(m => m.Email.Endereco.Equals(email)).SingleOrDefault();
        }

        public Usuario ObterPorPessoaId(Guid idPessoa)
        {
            return Buscar(m => m.Pessoa.IdPessoa == idPessoa).SingleOrDefault();
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return _context.Usuarios.ToList();
        }

        public void Remover(Guid id)
        {
            var usuario = _context.Usuarios.Find(id);
            _context.Usuarios.Remove(usuario);
        }        
    }
}
