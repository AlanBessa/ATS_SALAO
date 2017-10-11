using SBP.Application.Interfaces;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SBP.Presentation.Api.Controllers
{
    public class EstadoController : BaseController
    {
        private readonly IEstadoApp _estadoApp;

        public EstadoController(IEstadoApp estadoApp)
        {
            _estadoApp = estadoApp;
        }

        [HttpGet]
        [Authorize(Roles = "Gerente, Funcionario, SuperAdministrador")]
        [Route("api/estados")]
        public Task<HttpResponseMessage> Get()
        {
            var estados = _estadoApp.ObterTodos();

            if (estados == null)
                return CreateResponse(HttpStatusCode.InternalServerError, estados);

            return CreateResponse(HttpStatusCode.OK, estados);
        }
    }
}
