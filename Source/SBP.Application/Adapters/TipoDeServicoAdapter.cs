using SBP.Application.Command;
using SBP.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace SBP.Application.Adapters
{
    public class TipoDeServicoAdapter
    {
        public static TipoDeServico ToDomainModel(TipoDeServicoCommand tipoDeServicoCommand)
        {
            var tipoDeServico = new TipoDeServico(
                tipoDeServicoCommand.Titulo,
                tipoDeServicoCommand.Descricao,
                tipoDeServicoCommand.Preco,
                tipoDeServicoCommand.TempoGastoEmMinutos,
                tipoDeServicoCommand.IdTipoDeServico,
                tipoDeServicoCommand.EstabelecimentoId);
            
            return tipoDeServico;
        }

        public static TipoDeServicoCommand ToModelDomain(TipoDeServico tipoDeServico)
        {
            if (tipoDeServico == null) return null;

            var tipoDeServicoCommand = new TipoDeServicoCommand(
                tipoDeServico.Titulo,
                tipoDeServico.Descricao,
                tipoDeServico.Preco,
                tipoDeServico.TempoGastoEmMinutos,
                tipoDeServico.EstabelecimentoId);

            tipoDeServicoCommand.IdTipoDeServico = tipoDeServico.IdTipoDeServico;
            tipoDeServicoCommand.Estabelecimento = EstabelecimentoAdapter.ToModelDomain(tipoDeServico.Estabelecimento);

            return tipoDeServicoCommand;
        }
    }
}
