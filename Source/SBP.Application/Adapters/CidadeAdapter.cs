using SBP.Application.Command;
using SBP.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP.Application.Adapters
{
    public class CidadeAdapter
    {
        public static Cidade ToDomainModel(CidadeCommand cidadeCommand)
        {
            if (cidadeCommand == null) return null;

            var cidade = new Cidade(
                cidadeCommand.Nome,
                cidadeCommand.EstadoId.Value,
                cidadeCommand.IdCidade);

            return cidade;
        }

        public static CidadeCommand ToModelDomain(Cidade cidade)
        {
            if (cidade == null) return null;

            var cidadeCommand = new CidadeCommand(
                cidade.Nome,
                cidade.IdCidade,
                cidade.EstadoId);

            return cidadeCommand;
        }
    }
}
