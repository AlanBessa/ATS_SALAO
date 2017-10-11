using SBP.Domain.Entidades;
using System;

namespace SBP.Domain.Interfaces.Services
{
    public interface IEnderecoJuridicoService
    {
        EnderecoJuridico Atualizar(EnderecoJuridico enderecoJuridico);

        void Remover(Guid id);

        EnderecoJuridico ObterEnderecoJuridicoPorIdPessoaJuridico(Guid idPessoaJuridico);
    }
}
