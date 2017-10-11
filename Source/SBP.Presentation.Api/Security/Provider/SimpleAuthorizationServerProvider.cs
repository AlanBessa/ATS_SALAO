using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using SBP.Application.Interfaces;
using SBP.Presentation.Api.Security.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace SBP.Presentation.Api.Security.Provider
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private IUsuarioApp _usuarioApp;

        public SimpleAuthorizationServerProvider(IUsuarioApp usuarioApp)
        {
            _usuarioApp = usuarioApp;
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();

            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var usuario = _usuarioApp.Autenticar(context.UserName, context.Password);

            if (usuario == null)
            {
                context.SetError("invalid_grant", "Usuário ou senha inválidos");
                return;
            }

            if (!usuario.EstaAtivo)
            {
                context.SetError("invalid_grant", "Usuário está inativo.");
                return;
            }

            var identity = new ClaimsIdentity("JWT");
           
            identity.AddClaims(ExtendedClaimsProvider.GetClaims(usuario));
            identity.AddClaims(RolesFromClaims.CreateRolesBasedOnClaims(identity));

            AuthenticationProperties properties = CreateProperties(usuario.IdPessoa.ToString(), usuario.Funcionario.Imagem, usuario.Funcionario.Estabelecimento.Logo);
            AuthenticationTicket ticket = new AuthenticationTicket(identity, properties);

            context.Validated(ticket);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
        
        public static AuthenticationProperties CreateProperties(string userName, string foto, string logoEmpresa)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName },
                { "foto", foto },
                { "logoEmpresa", logoEmpresa }
            };
            return new AuthenticationProperties(data);
        }
    }
}