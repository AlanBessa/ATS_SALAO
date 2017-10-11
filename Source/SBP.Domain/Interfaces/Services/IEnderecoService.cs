using SBP.Domain.Entidades;
using System;

namespace SBP.Domain.Interfaces.Services
{
    public interface IEnderecoService
    {
        Endereco Atualizar(Endereco endereco);

        void Remover(Guid id);

        Endereco ObterEnderecoPorIdPessoa(Guid idPessoa);
    }
}
