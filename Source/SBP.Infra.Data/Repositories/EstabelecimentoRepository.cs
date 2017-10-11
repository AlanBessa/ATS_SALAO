using SBP.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using SBP.Domain.Entidades;
using System.Linq.Expressions;
using SBP.Infra.Data.Context;
using System.Data.Entity;

namespace SBP.Infra.Data.Repositories
{
    public class EstabelecimentoRepository : IEstabelecimentoRepository
    {
        private readonly SalaoAgendadorContext _context;

        public EstabelecimentoRepository(SalaoAgendadorContext context)
        {
            _context = context;
        }

        public void Adicionar(Estabelecimento estabelecimento)
        {
            _context.Estabelecimentos.Add(estabelecimento);
        }

        public void Atualizar(Estabelecimento estabelecimento)
        {
            _context.Entry(estabelecimento).State = EntityState.Modified;
        }

        public IEnumerable<Estabelecimento> Buscar(Expression<Func<Estabelecimento, bool>> predicate)
        {
            return _context.Estabelecimentos.Where(predicate);
        }

        public Estabelecimento ObterPorCNPJ(string cnpj)
        {
            return Buscar(m => m.CNPJ.Codigo.Equals(cnpj)).SingleOrDefault();
        }

        public Estabelecimento ObterPorId(Guid id)
        {
            return _context.Estabelecimentos.Find(id);
        }

        public IEnumerable<Estabelecimento> ObterTodos()
        {
            return _context.Estabelecimentos.ToList();
        }

        public void Remover(Guid id)
        {
            var estabelecimento = _context.Estabelecimentos.Find(id);
            _context.Estabelecimentos.Remove(estabelecimento);
        }
    }
}
