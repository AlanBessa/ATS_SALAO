using SBP.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using SBP.Domain.Entidades;
using System.Linq.Expressions;
using SBP.Infra.Data.Context;
using System.Data.Entity;
using SBP.Domain.SharedKernel.Enum;

namespace SBP.Infra.Data.Repositories
{
    public class AgendaRepository : IAgendaRepository
    {
        private readonly SalaoAgendadorContext _context;

        public AgendaRepository(SalaoAgendadorContext context)
        {
            _context = context;
        }

        public void Adicionar(Agenda agenda)
        {
            _context.Agendas.Add(agenda);
        }

        public void Atualizar(Agenda agenda)
        {
            _context.Entry(agenda).State = EntityState.Modified;
        }

        public IEnumerable<Agenda> Buscar(Expression<Func<Agenda, bool>> predicate)
        {
            return _context.Agendas.Include("Cliente").Include("Funcionario").Where(predicate);
        }

        public Agenda ObterPorFiltro(DateTime dataInicio, Guid idFuncionario, Guid idEstabelecimento)
        {
            return Buscar(m => m.DataInicioDoAgendamento == dataInicio && m.FuncionarioId == idFuncionario && m.EstabelecimentoId == idEstabelecimento)
                    .Where(m => m.Status != EStatus.Cancelado).SingleOrDefault();
        }

        public Agenda ObterPorId(Guid id)
        {
            return Buscar(m => m.IdAgenda == id).SingleOrDefault();
        }

        public IEnumerable<Agenda> ObterTodos()
        {
            return _context.Agendas.ToList();
        }

        public IEnumerable<Agenda> ObterTodosPor(Guid idEstabelecimento, Guid idFuncionario)
        {
            return Buscar(m => m.EstabelecimentoId == idEstabelecimento && m.FuncionarioId == idFuncionario).ToList();
        }

        public IEnumerable<Agenda> ObterTodosPorEstabelecimento(Guid idEstabelecimento)
        {
            return Buscar(m => m.EstabelecimentoId == idEstabelecimento).ToList();
        }

        public void Remover(Guid id)
        {
            var agenda = _context.Agendas.Find(id);
            _context.Agendas.Remove(agenda);
        }
    }
}
