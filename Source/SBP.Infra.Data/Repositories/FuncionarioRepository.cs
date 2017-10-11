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
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly SalaoAgendadorContext _context;

        public FuncionarioRepository(SalaoAgendadorContext context)
        {
            _context = context;
        }

        public void Adicionar(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
        }

        public void Atualizar(Funcionario funcionario)
        {
            _context.Entry(funcionario).State = EntityState.Modified;
        }

        public IEnumerable<Funcionario> Buscar(Expression<Func<Funcionario, bool>> predicate)
        {
            return _context.Funcionarios.Include("Estabelecimento").Where(predicate);
        }

        public Funcionario ObterPorCPF(string cpf)
        {
            return Buscar(m => m.CPF.Codigo.Equals(cpf)).SingleOrDefault();
        }

        public Funcionario ObterPrimeiroFuncionarioPorEstabelecimento(Guid idEstabelecimento)
        {
            return _context.Funcionarios.Where(m => m.EstabelecimentoId == idEstabelecimento).FirstOrDefault();
        }

        public Funcionario ObterPorId(Guid id)
        {
            return Buscar(m => m.IdPessoa == id).SingleOrDefault();
        }

        public IEnumerable<Funcionario> ObterTodos()
        {
            return _context.Funcionarios.ToList();
        }

        public void Remover(Guid id)
        {
            var funcionario = _context.Funcionarios.Find(id);
            _context.Funcionarios.Remove(funcionario);
        }
    }
}
