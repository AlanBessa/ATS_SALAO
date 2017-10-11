using DomainValidation.Interfaces.Specification;
using SBP.Domain.Entidades;
using SBP.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP.Domain.Specifications
{
    public class UsuarioDevePossuirEmailUnicoSpecification : ISpecification<Usuario>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioDevePossuirEmailUnicoSpecification(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public bool IsSatisfiedBy(Usuario usuario)
        {
            var user = _usuarioRepository.ObterPorEmail(usuario.Email.Endereco);

            return (user == null || (user != null && user.Email.Endereco.Equals(usuario.Email.Endereco)));
        }
    }
}
