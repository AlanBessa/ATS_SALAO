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
    public class ClienteRepository : IClienteRepository
    {
        private readonly SalaoAgendadorContext _context;

        public ClienteRepository(SalaoAgendadorContext context)
        {
            _context = context;
        }

        public void Adicionar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
        }

        public void Atualizar(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
        }

        public IEnumerable<Cliente> Buscar(Expression<Func<Cliente, bool>> predicate)
        {
            return _context.Clientes.Where(predicate);
        }

        public Cliente ObterPorCPF(string cpf)
        {
            return Buscar(m => m.CPF.Codigo.Equals(cpf)).SingleOrDefault();
        }

        public Cliente ObterPorId(Guid id)
        {
            return _context.Clientes.Find(id);
        }
        
        public IEnumerable<Cliente> ObterTodos()
        {
            return _context.Clientes.ToList();
        }

        public void Remover(Guid id)
        {
            var cliente = _context.Clientes.Find(id);
            _context.Clientes.Remove(cliente);
        }
    }
}
