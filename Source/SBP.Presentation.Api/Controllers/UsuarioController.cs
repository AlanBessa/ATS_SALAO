using SBP.Application.Command;
using SBP.Application.Interfaces;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SBP.Presentation.Api.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioApp _usuarioApp;

        public UsuarioController(IUsuarioApp usuarioApp)
        {
            _usuarioApp = usuarioApp;
        }

        [HttpGet]
        [Authorize(Roles = "Gerente, Funcionario, SuperAdministrador")]
        [Route("api/usuarios/{id:guid}")]
        public Task<HttpResponseMessage> Get(Guid id)
        {
            var usuario = _usuarioApp.ObterPorId(id);

            if (usuario == null)
                return CreateResponse(HttpStatusCode.InternalServerError, usuario);

            return CreateResponse(HttpStatusCode.OK, usuario);
        }

        //[HttpGet]
        //[Authorize(Roles = "SuperAdministrador")]
        //[Route("api/usuarios/{id:guid}/{empresa:guid}")]
        //public Task<HttpResponseMessage> GetAlt(Guid id)
        //{
        //    var usuario = _usuarioApp.ObterPorId(id);

        //    if (usuario == null)
        //        return CreateResponse(HttpStatusCode.InternalServerError, usuario);

        //    return CreateResponse(HttpStatusCode.OK, usuario);
        //}

        //[HttpGet]
        //[Authorize(Roles = "usuario")]
        //[Route("api/usuarios")]
        //public Task<HttpResponseMessage> Get()
        //{
        //    var usuarios = _usuarioApp.ObterTodos();

        //    if (usuarios == null)
        //        return CreateResponse(HttpStatusCode.InternalServerError, usuarios);

        //    return CreateResponse(HttpStatusCode.OK, usuarios);
        //}

        [HttpPost]
        [Authorize(Roles = "Gerente")]
        [Route("api/usuarios")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var usuarioCommand = new UsuarioCommand(
                    email: (string)body.email,
                    senha: (string)body.confirmarSenha,
                    perfil: (int)body.perfil,
                    estaAtivo: (bool)body.estaAtivo,
                    idPessoa: (Guid)body.idPessoa
                );

            var usuario = _usuarioApp.Cadastrar(usuarioCommand);

            return CreateResponse(HttpStatusCode.Created, usuario);
        }

        [HttpPut]
        [Authorize(Roles = "Gerente, SuperAdministrador")]
        [Route("api/usuarios/{id:guid}")]
        public Task<HttpResponseMessage> Put(Guid id, [FromBody]dynamic body)
        {
            var usuarioCommand = new UsuarioCommand(
                    email: (string)body.email,
                    senha: (string)body.confirmarSenha,
                    perfil: (int)body.perfil,
                    estaAtivo: (bool)body.estaAtivo,
                    idPessoa: (Guid)body.idPessoa
                );

            var usuario = _usuarioApp.Atualizar(usuarioCommand);

            return CreateResponse(HttpStatusCode.OK, usuario);
        }

        [HttpPut]
        [Authorize(Roles = "Gerente, Funcionario, SuperAdministrador")]
        [Route("api/usuarios/{id:guid}/senha")]
        public Task<HttpResponseMessage> AtualizarSenha(Guid id, [FromBody]dynamic body)
        {
            var usuarioCommand = new UsuarioCommand(
                    senha: (string)body.confirmarSenha,
                    idPessoa: (Guid)body.idPessoa
                );

            var usuario = _usuarioApp.AtualizarSenha(usuarioCommand);

            return CreateResponse(HttpStatusCode.OK, usuario);
        }
    }
}
