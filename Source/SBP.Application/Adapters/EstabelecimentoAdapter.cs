using SBP.Application.Command;
using SBP.Domain.Entidades;
using SBP.Domain.SharedKernel.Helpers;
using System.Linq;

namespace SBP.Application.Adapters
{
    public class EstabelecimentoAdapter
    {
        public static Estabelecimento ToDomainModel(EstabelecimentoCommand estabelecimentoCommand)
        {
            var estabelecimento = new Estabelecimento(
                estabelecimentoCommand.RazaoSocial,
                estabelecimentoCommand.NomeFantasia,
                estabelecimentoCommand.Email,
                estabelecimentoCommand.CNPJ,
                estabelecimentoCommand.Telefone,
                estabelecimentoCommand.Descricao,
                estabelecimentoCommand.Logo,
                estabelecimentoCommand.IdPessoaJuridica);
            
            estabelecimento.AdicionarEndereco(EnderecoJuridicoAdapter.ToDomainModel(estabelecimentoCommand.EnderecoJuridico));

            return estabelecimento;
        }

        public static EstabelecimentoCommand ToModelDomain(Estabelecimento estabelecimento)
        {
            if (estabelecimento == null) return null;

            var estabelecimentoCommand = new EstabelecimentoCommand(
                estabelecimento.RazaoSocial,
                estabelecimento.NomeFantasia,
                estabelecimento.Email.Endereco,
                estabelecimento.CNPJ.Codigo,
                estabelecimento.Telefone.Numero,
                ImageHelper.ConverterParaBase64String(estabelecimento.Logo),
                estabelecimento.Descricao);

            estabelecimentoCommand.IdPessoaJuridica = estabelecimento.IdPessoaJuridica;
            estabelecimentoCommand.EstaAtivo = estabelecimento.EstaAtivo;
            
            if (estabelecimento.ListaDeEnderecosJuridicos != null)
                estabelecimentoCommand.EnderecoJuridico = EnderecoJuridicoAdapter.ToModelDomain(estabelecimento.ListaDeEnderecosJuridicos.FirstOrDefault());

            if (estabelecimento.ListaDeFuncionarios != null && estabelecimento.ListaDeFuncionarios.Any())
                estabelecimentoCommand.PrimeiroFuncionario = FuncionarioAdapter.ToModelDomain(estabelecimento.ListaDeFuncionarios.FirstOrDefault());

            return estabelecimentoCommand;
        }
    }
}
