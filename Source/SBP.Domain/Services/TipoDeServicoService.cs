using SBP.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using SBP.Domain.Entidades;
using SBP.Domain.Interfaces.Repositories;

namespace SBP.Domain.Services
{
    public class TipoDeServicoService : BaseService, ITipoDeServicoService
    {
        private readonly ITipoDeServicoRepository _tipoDeServicoRepository;

        public TipoDeServicoService(ITipoDeServicoRepository tipoDeServicoRepository)
        {
            _tipoDeServicoRepository = tipoDeServicoRepository;
        }

        public TipoDeServico Adicionar(TipoDeServico tipoDeServico)
        {
            _tipoDeServicoRepository.Adicionar(tipoDeServico);

            return tipoDeServico;
        }

        public TipoDeServico Atualizar(TipoDeServico tipoDeServico)
        {
            _tipoDeServicoRepository.Atualizar(tipoDeServico);

            return tipoDeServico;
        }

        public TipoDeServico Remover(Guid id)
        {
            var tipoDeServico = _tipoDeServicoRepository.ObterPorId(id);

            _tipoDeServicoRepository.Remover(tipoDeServico);

            return tipoDeServico;
        }

        public TipoDeServico ObterPorId(Guid id)
        {
            return _tipoDeServicoRepository.ObterPorId(id);
        }

        public IEnumerable<TipoDeServico> ObterTodos()
        {
            return _tipoDeServicoRepository.ObterTodos();
        }

        public IEnumerable<TipoDeServico> ObterTodos(int skip, int take)
        {
            return _tipoDeServicoRepository.ObterTodos(skip, take);
        }

        public IEnumerable<TipoDeServico> ObterTodosPor(Guid idEstabelecimento)
        {
            return _tipoDeServicoRepository.ObterTodosPor(idEstabelecimento);
        }
    }
}
