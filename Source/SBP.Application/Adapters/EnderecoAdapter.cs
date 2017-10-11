using SBP.Application.Command;
using SBP.Domain.Entidades;

namespace SBP.Application.Adapters
{
    public class EnderecoAdapter
    {
        public static Endereco ToDomainModel(EnderecoCommand enderecoCommand)
        {
            if (enderecoCommand == null) return null;

            var endereco = new Endereco(
                enderecoCommand.Logradouro,
                enderecoCommand.Complemento,
                enderecoCommand.Numero,
                enderecoCommand.Bairro,
                enderecoCommand.CidadeId,
                enderecoCommand.EstadoId,
                enderecoCommand.Cep);

            if (enderecoCommand.IdEndereco != null) endereco.IdEndereco = enderecoCommand.IdEndereco.Value;

            return endereco;
        }

        public static EnderecoCommand ToModelDomain(Endereco endereco)
        {
            if (endereco == null) return null;

            var enderecoCommand = new EnderecoCommand(
                endereco.Logradouro,
                endereco.Numero,
                endereco.Complemento,
                endereco.Bairro,
                endereco.Cep.CepCod,
                endereco.CidadeId,
                endereco.EstadoId);

            enderecoCommand.IdEndereco = endereco.IdEndereco;
            enderecoCommand.Estado = EstadoAdapter.ToModelDomain(endereco.Estado);
            enderecoCommand.Cidade = CidadeAdapter.ToModelDomain(endereco.Cidade);

            return enderecoCommand;
        }
    }
}
