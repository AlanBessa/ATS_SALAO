using SBP.Application.Command;
using SBP.Domain.Entidades;
using SBP.Domain.SharedKernel.Helpers;
using System.Linq;

namespace SBP.Application.Adapters
{
    public class FuncionarioAdapter
    {
        public static Funcionario ToDomainModel(FuncionarioCommand funcionarioCommand)
        {
            var funcionario = new Funcionario(
                funcionarioCommand.Nome,
                funcionarioCommand.CPF,
                funcionarioCommand.Celular,
                funcionarioCommand.IdPessoa,
                funcionarioCommand.Funcao,
                funcionarioCommand.EstabelecimentoId,
                funcionarioCommand.Imagem);

            if (!string.IsNullOrEmpty(funcionarioCommand.Email)) funcionario.DefinirEmail(funcionarioCommand.Email);

            funcionario.AdicionarEndereco(EnderecoAdapter.ToDomainModel(funcionarioCommand.Endereco));

            if (funcionarioCommand.EstabelecimentoId != null) funcionario.DefinirEstabelecimento(funcionarioCommand.EstabelecimentoId);
            //if(funcionarioCommand.UsuarioId != null) funcionario.DefinirUsuario(funcionarioCommand.UsuarioId);

            return funcionario;
        }

        public static FuncionarioCommand ToModelDomain(Funcionario funcionario)
        {
            if (funcionario == null) return null;

            var funcionarioCommand = new FuncionarioCommand(
                funcionario.Nome,
                funcionario.CPF.Codigo,
                funcionario.Celular.Numero,
                funcionario.Email.Endereco,
                funcionario.Funcao,
                funcionario.EstabelecimentoId,
                ImageHelper.ConverterParaBase64String(funcionario.Imagem));

            funcionarioCommand.IdPessoa = funcionario.IdPessoa;
            funcionarioCommand.EstaAtivo = funcionario.EstaAtivo;

            if(funcionario.ListaDeEnderecos != null)
                funcionarioCommand.Endereco = EnderecoAdapter.ToModelDomain(funcionario.ListaDeEnderecos.FirstOrDefault());

            funcionarioCommand.Estabelecimento = EstabelecimentoAdapter.ToModelDomain(funcionario.Estabelecimento);
            funcionarioCommand.Usuario = UsuarioAdapter.ToModelDomain(funcionario.Usuario);

            return funcionarioCommand;
        }
    }
}
