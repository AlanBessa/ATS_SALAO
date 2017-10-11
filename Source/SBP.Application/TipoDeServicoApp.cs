using SBP.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using SBP.Application.Command;
using SBP.Infra.Data.UoW;
using SBP.Domain.Interfaces.Services;
using SBP.Application.Adapters;

namespace SBP.Application
{
    public class TipoDeServicoApp : BaseApp, ITipoDeServicoApp
    {
        private readonly ITipoDeServicoService _tipoDeServicoService;

        public TipoDeServicoApp(ITipoDeServicoService tipoDeServicoService, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _tipoDeServicoService = tipoDeServicoService;
        }

        public TipoDeServicoCommand Cadastrar(TipoDeServicoCommand tipoDeServicoCommand)
        {
            var tipoDeServico = _tipoDeServicoService.Adicionar(TipoDeServicoAdapter.ToDomainModel(tipoDeServicoCommand));

            if (Commit())
                return TipoDeServicoAdapter.ToModelDomain(tipoDeServico);

            return null;
        }

        public TipoDeServicoCommand Atualizar(TipoDeServicoCommand tipoDeServicoCommand)
        {
            var tipoDeServico = _tipoDeServicoService.ObterPorId(tipoDeServicoCommand.IdTipoDeServico.Value);

            tipoDeServico.AtualizarDados(tipoDeServicoCommand.Titulo, tipoDeServicoCommand.Descricao, tipoDeServicoCommand.Preco, 
                                         tipoDeServicoCommand.TempoGastoEmMinutos);

            var tipoDeServicoRetorno = _tipoDeServicoService.Atualizar(tipoDeServico);

            if (Commit())
                return TipoDeServicoAdapter.ToModelDomain(tipoDeServicoRetorno);

            return null;
        }

        public TipoDeServicoCommand Remover(Guid id)
        {
            var tipoDeServico = _tipoDeServicoService.Remover(id);

            if (Commit())
                return TipoDeServicoAdapter.ToModelDomain(tipoDeServico);

            return null;
        }

        public TipoDeServicoCommand ObterPorId(Guid id)
        {
            var tipoDeServico = _tipoDeServicoService.ObterPorId(id);

            return TipoDeServicoAdapter.ToModelDomain(tipoDeServico);
        }

        public IEnumerable<TipoDeServicoCommand> ObterTodos()
        {
            var lista = new List<TipoDeServicoCommand>();

            _tipoDeServicoService.ObterTodos().ToList().ForEach(m => lista.Add(TipoDeServicoAdapter.ToModelDomain(m)));

            return lista;
        }        

        public IEnumerable<TipoDeServicoCommand> ObterTodos(int skip, int take)
        {
            var lista = new List<TipoDeServicoCommand>();

            _tipoDeServicoService.ObterTodos(skip, take).ToList().ForEach(m => lista.Add(TipoDeServicoAdapter.ToModelDomain(m)));

            return lista;
        }

        public IEnumerable<TipoDeServicoCommand> ObterTodosPor(Guid idEstabelecimento)
        {
            var lista = new List<TipoDeServicoCommand>();

            _tipoDeServicoService.ObterTodosPor(idEstabelecimento).ToList().ForEach(m => lista.Add(TipoDeServicoAdapter.ToModelDomain(m)));

            return lista;
        }
    }
}
