using SBP.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using SBP.Domain.Entidades;
using SBP.Infra.Data.Context;
using System;
using System.Linq.Expressions;
using System.Data.Entity;

namespace SBP.Infra.Data.Repositories
{
    public class CidadeRepository : ICidadeRepository
    {
        private readonly SalaoAgendadorContext _context;

        public CidadeRepository(SalaoAgendadorContext context)
        {
            _context = context;
        }

        public void Adicionar(Cidade cidade)
        {
            _context.Cidades.Add(cidade);
        }

        public void Atualizar(Cidade cidade)
        {
            _context.Entry(cidade).State = EntityState.Modified;
        }

        public IEnumerable<Cidade> Buscar(Expression<Func<Cidade, bool>> predicate)
        {
            return _context.Cidades.Where(predicate);
        }

        public Cidade ObterPorId(Guid id)
        {
            return _context.Cidades.Find(id);
        }

        public IEnumerable<Cidade> ObterTodos(Guid idEstado)
        {
            return Buscar(m => m.EstadoId == idEstado).ToList();
        }

        public IEnumerable<Cidade> ObterTodos()
        {
            return _context.Cidades.ToList();
        }

        public void Remover(Guid id)
        {
            var cidade = _context.Cidades.Find(id);
            _context.Cidades.Remove(cidade);
        }
    }
}
