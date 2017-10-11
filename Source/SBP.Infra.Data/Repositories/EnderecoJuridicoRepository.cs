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
    public class EnderecoJuridicoRepository : IEnderecoJuridicoRepository
    {
        private readonly SalaoAgendadorContext _context;

        public EnderecoJuridicoRepository(SalaoAgendadorContext context)
        {
            _context = context;
        }

        public void Adicionar(EnderecoJuridico enderecoJuridico)
        {
            _context.EnderecosJuridicos.Add(enderecoJuridico);
        }

        public void Atualizar(EnderecoJuridico enderecoJuridico)
        {
            _context.Entry(enderecoJuridico).State = EntityState.Modified;
        }

        public IEnumerable<EnderecoJuridico> Buscar(Expression<Func<EnderecoJuridico, bool>> predicate)
        {
            return _context.EnderecosJuridicos.Include("Cidade").Include("Estado").Where(predicate);
        }

        public EnderecoJuridico ObterPorId(Guid id)
        {
            return _context.EnderecosJuridicos.Find(id);
        }

        public EnderecoJuridico ObterPorPessoaJuridicoId(Guid idPessoaJuridico)
        {
            return Buscar(m => m.PessoaJuridicaId == idPessoaJuridico).SingleOrDefault();
        }

        public IEnumerable<EnderecoJuridico> ObterTodos()
        {
            return _context.EnderecosJuridicos.ToList();
        }

        public void Remover(Guid id)
        {
            var enderecoJuridico = _context.EnderecosJuridicos.Find(id);
            _context.EnderecosJuridicos.Remove(enderecoJuridico);
        }
    }
}
