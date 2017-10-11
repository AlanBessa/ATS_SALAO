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
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly SalaoAgendadorContext _context;

        public EnderecoRepository(SalaoAgendadorContext context)
        {
            _context = context;
        }

        public void Adicionar(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
        }

        public void Atualizar(Endereco endereco)
        {
            _context.Entry(endereco).State = EntityState.Modified;
        }

        public IEnumerable<Endereco> Buscar(Expression<Func<Endereco, bool>> predicate)
        {
            return _context.Enderecos.Include("Cidade").Include("Estado").Where(predicate);
        }

        public Endereco ObterPorId(Guid id)
        {
            return _context.Enderecos.Find();
        }

        public Endereco ObterPorPessoaId(Guid idPessoa)
        {
            return Buscar(m => m.PessoaId == idPessoa).SingleOrDefault();
        }

        public IEnumerable<Endereco> ObterTodos()
        {
            return _context.Enderecos.ToList();
        }

        public void Remover(Guid id)
        {
            var endereco = _context.Enderecos.Find(id);
            _context.Enderecos.Remove(endereco);
        }
    }
}
