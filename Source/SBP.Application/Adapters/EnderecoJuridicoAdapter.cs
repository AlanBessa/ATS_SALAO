using SBP.Application.Command;
using SBP.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP.Application.Adapters
{
    public class EnderecoJuridicoAdapter
    {
        public static EnderecoJuridico ToDomainModel(EnderecoJuridicoCommand enderecoJuridicoCommand)
        {
            if (enderecoJuridicoCommand == null) return null;

            var enderecoJuridico = new EnderecoJuridico(
                enderecoJuridicoCommand.Logradouro,
                enderecoJuridicoCommand.Complemento,
                enderecoJuridicoCommand.Numero,
                enderecoJuridicoCommand.Bairro,
                enderecoJuridicoCommand.CidadeId,
                enderecoJuridicoCommand.EstadoId,
                enderecoJuridicoCommand.Cep);

            if (enderecoJuridicoCommand.IdEndereco != null) enderecoJuridico.IdEndereco = enderecoJuridicoCommand.IdEndereco.Value;

            return enderecoJuridico;
        }

        public static EnderecoJuridicoCommand ToModelDomain(EnderecoJuridico enderecoJuridico)
        {
            if (enderecoJuridico == null) return null;

            var enderecoJuridicoCommand = new EnderecoJuridicoCommand(
                enderecoJuridico.Logradouro,
                enderecoJuridico.Numero,
                enderecoJuridico.Complemento,
                enderecoJuridico.Bairro,
                enderecoJuridico.Cep.CepCod,
                enderecoJuridico.CidadeId,
                enderecoJuridico.EstadoId);

            enderecoJuridicoCommand.IdEndereco = enderecoJuridico.IdEndereco;
            enderecoJuridicoCommand.Estado = EstadoAdapter.ToModelDomain(enderecoJuridico.Estado);
            enderecoJuridicoCommand.Cidade = CidadeAdapter.ToModelDomain(enderecoJuridico.Cidade);

            return enderecoJuridicoCommand;
        }
    }
}
