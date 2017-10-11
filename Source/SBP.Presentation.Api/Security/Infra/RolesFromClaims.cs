using SBP.Domain.SharedKernel.Enum;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace SBP.Presentation.Api.Security.Infra
{
    public class RolesFromClaims
    {
        public static IEnumerable<Claim> CreateRolesBasedOnClaims(ClaimsIdentity identity)
        {
            List<Claim> claims = new List<Claim>();

            if (identity.HasClaim(c => c.Type == "PER" && c.Value == Convert.ToInt32(EPerfil.Funcionario).ToString()))
            {
                claims.Add(new Claim(ClaimTypes.Role, "Funcionario"));
            }
            else if (identity.HasClaim(c => c.Type == "PER" && c.Value == Convert.ToInt32(EPerfil.Gerente).ToString()))
            {
                claims.Add(new Claim(ClaimTypes.Role, "Gerente"));
            }
            else if (identity.HasClaim(c => c.Type == "PER" && c.Value == Convert.ToInt32(EPerfil.SuperAdministrador).ToString()))
            {
                claims.Add(new Claim(ClaimTypes.Role, "SuperAdministrador"));
            }

            return claims;
        }
    }
}