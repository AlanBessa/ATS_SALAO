using SBP.Application.Command;
using SBP.Domain.SharedKernel.Enum;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace SBP.Presentation.Api.Security.Provider
{
    public static class ExtendedClaimsProvider
    {
        public static IEnumerable<Claim> GetClaims(UsuarioCommand usuario)
        {
            List<Claim> claims = new List<Claim>();
            
            if (usuario.Perfil == (int)EPerfil.Funcionario)
            {
                claims.Add(CreateClaim("PER", Convert.ToInt32(EPerfil.Funcionario).ToString()));    
            }
            else if (usuario.Perfil == (int)EPerfil.Gerente)
            {
                claims.Add(CreateClaim("PER", Convert.ToInt32(EPerfil.Gerente).ToString()));
            }
            else if (usuario.Perfil == (int)EPerfil.SuperAdministrador)
            {
                claims.Add(CreateClaim("PER", Convert.ToInt32(EPerfil.SuperAdministrador).ToString()));
            }            

            claims.Add(CreateClaim("FUN", usuario.Funcionario.IdPessoa.ToString()));
            claims.Add(CreateClaim("FUNNOM", usuario.Funcionario.Nome));
            claims.Add(CreateClaim("EST", usuario.Funcionario.EstabelecimentoId.ToString()));
            claims.Add(CreateClaim("PROF", usuario.Funcionario.Funcao));

            return claims;
        }

        public static Claim CreateClaim(string type, string value)
        {
            return new Claim(type, value, ClaimValueTypes.String);
        }
    }
}