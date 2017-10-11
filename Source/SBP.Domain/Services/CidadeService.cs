using SBP.Domain.Interfaces.Services;
using System;
using System.Linq;
using System.Collections.Generic;
using SBP.Domain.Entidades;
using SBP.Domain.Interfaces.Repositories;

namespace SBP.Domain.Services
{
    public class CidadeService : ICidadeService
    {
        private readonly ICidadeRepository _cidadeRepository;

        public CidadeService(ICidadeRepository cidadeRepository)
        {
            _cidadeRepository = cidadeRepository;
        }

        public IEnumerable<Cidade> ObterTodos(Guid idEstado)
        {
            return _cidadeRepository.ObterTodos(idEstado).OrderBy(m => m.Nome).ToList();
        }
    }
}
