using SBP.Application.Interfaces;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SBP.Presentation.Api.Controllers
{
    public class CidadeController : BaseController
    {
        private readonly ICidadeApp _cidadeApp;

        public CidadeController(ICidadeApp cidadeApp)
        {
            _cidadeApp = cidadeApp;
        }

        [HttpGet]
        [Authorize(Roles = "Gerente, Funcionario, SuperAdministrador")]
        [Route("api/cidades/estado/{id:guid}")]
        public Task<HttpResponseMessage> GetByEstado(Guid id)
        {
            var cidades = _cidadeApp.ObterTodos(id);

            if (cidades == null)
                return CreateResponse(HttpStatusCode.InternalServerError, cidades);

            return CreateResponse(HttpStatusCode.OK, cidades);
        }
    }
}
