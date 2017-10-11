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
    public class TipoDeServicoRepository : ITipoDeServicoRepository
    {
        private readonly SalaoAgendadorContext _context;

        public TipoDeServicoRepository(SalaoAgendadorContext context)
        {
            _context = context;
        }

        public void Adicionar(TipoDeServico tipoDeServico)
        {
            _context.TiposDeServico.Add(tipoDeServico);
        }

        public void Atualizar(TipoDeServico tipoDeServico)
        {
            _context.Entry(tipoDeServico).State = EntityState.Modified;
        }

        public IEnumerable<TipoDeServico> Buscar(Expression<Func<TipoDeServico, bool>> predicate)
        {
            return _context.TiposDeServico.Where(predicate);
        }

        public TipoDeServico ObterPorId(Guid id)
        {
            return _context.TiposDeServico.Find(id);
        }

        public IEnumerable<TipoDeServico> ObterTodos()
        {
            return _context.TiposDeServico.ToList();
        }

        public List<TipoDeServico> ObterTodos(int skip, int take)
        {
            return _context.TiposDeServico.OrderBy(x => x.Titulo).Skip(skip).Take(take).ToList();
        }

        public IEnumerable<TipoDeServico> ObterTodosPor(Guid idEstabelecimento)
        {
            return Buscar(m => m.EstabelecimentoId == idEstabelecimento).ToList();
        }

        public void Remover(TipoDeServico tipoDeServico)
        {            
            _context.TiposDeServico.Remove(tipoDeServico);
        }
    }
}
