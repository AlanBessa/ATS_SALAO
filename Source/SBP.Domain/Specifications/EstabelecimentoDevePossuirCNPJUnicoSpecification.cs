using DomainValidation.Interfaces.Specification;
using SBP.Domain.Entidades;
using SBP.Domain.Interfaces.Repositories;

namespace SBP.Domain.Specifications
{
    public class EstabelecimentoDevePossuirCNPJUnicoSpecification : ISpecification<Estabelecimento>
    {
        private readonly IEstabelecimentoRepository _estabelecimentoRepository;

        public EstabelecimentoDevePossuirCNPJUnicoSpecification(IEstabelecimentoRepository estabelecimentoRepository)
        {
            _estabelecimentoRepository = estabelecimentoRepository;
        }
        
        public bool IsSatisfiedBy(Estabelecimento estabelecimento)
        {
            var estab = _estabelecimentoRepository.ObterPorCNPJ(estabelecimento.CNPJ.Codigo);

            return (estab == null || (estab != null && estab.IdPessoaJuridica == estabelecimento.IdPessoaJuridica));
        }
    }
}
