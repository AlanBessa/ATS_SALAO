using SBP.Application.Command;
using SBP.Application.Interfaces;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SBP.Presentation.Api.Controllers
{
    public class ContatoController : BaseController
    {
        private readonly IUsuarioApp _usuarioApp;

        public ContatoController(IUsuarioApp usuarioApp)
        {
            _usuarioApp = usuarioApp;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/Contato")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new ContatoCommand(
                nome: (string)body.nome,
                email: (string)body.email,
                celular: (string)body.celular,
                mensagem: (string)body.mensagem
            );

            var FoiEnviado = !_usuarioApp.EnviarContatoPorEmail(command);

            if (!FoiEnviado)
            {
                return CreateResponse(HttpStatusCode.InternalServerError, FoiEnviado);
            }

            return CreateResponse(HttpStatusCode.OK, FoiEnviado);
        }
    }
}
