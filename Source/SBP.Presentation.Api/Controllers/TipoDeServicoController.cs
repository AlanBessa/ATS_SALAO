using SBP.Application.Command;
using SBP.Application.Interfaces;
using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SBP.Presentation.Api.Controllers
{
    public class TipoDeServicoController : BaseController
    {
        private readonly ITipoDeServicoApp _tipoDeServicoApp;

        public TipoDeServicoController(ITipoDeServicoApp tipoDeServicoApp)
        {
            _tipoDeServicoApp = tipoDeServicoApp;
        }

        [HttpGet]
        [Authorize(Roles = "Gerente")]
        [Route("api/tiposdeservico/{id:guid}")]
        public Task<HttpResponseMessage> Get(Guid id)
        {
            var tipoDeServico = _tipoDeServicoApp.ObterPorId(id);

            if (tipoDeServico == null)
                return CreateResponse(HttpStatusCode.InternalServerError, tipoDeServico);

            return CreateResponse(HttpStatusCode.OK, tipoDeServico);
        }

        [HttpGet]
        [Authorize(Roles = "Gerente")]
        [Route("api/tiposdeservico")]
        public Task<HttpResponseMessage> Get()
        {
            var tiposDeServico = _tipoDeServicoApp.ObterTodos();

            if (tiposDeServico == null)
                return CreateResponse(HttpStatusCode.InternalServerError, tiposDeServico);

            return CreateResponse(HttpStatusCode.OK, tiposDeServico);
        }

        //[HttpGet]
        //[Authorize(Roles = "usuario")]
        //[Route("api/tiposdeservico/{skip}/{take}")]
        //public Task<HttpResponseMessage> Get(int skip, int take)
        //{
        //    var tiposDeServico = _tipoDeServicoApp.ObterTodos(skip, take);

        //    if (tiposDeServico == null)
        //        return CreateResponse(HttpStatusCode.InternalServerError, tiposDeServico);

        //    return CreateResponse(HttpStatusCode.OK, tiposDeServico);
        //}

        [HttpGet]
        [Authorize(Roles = "Gerente")]
        [Route("api/tiposdeservico/estabelecimento/{id:guid}")]
        public Task<HttpResponseMessage> ObterTodosPorEstabelecimento(Guid id)
        {
            var tiposDeServico = _tipoDeServicoApp.ObterTodosPor(id);

            if (tiposDeServico == null)
                return CreateResponse(HttpStatusCode.InternalServerError, tiposDeServico);

            return CreateResponse(HttpStatusCode.OK, tiposDeServico);
        }

        [HttpPost]
        [Authorize(Roles = "Gerente")]
        [Route("api/tiposdeservico")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var ci = CultureInfo.InvariantCulture.Clone() as CultureInfo;
            ci.NumberFormat.NumberDecimalSeparator = ",";

            var tipoDeServicoCommand = new TipoDeServicoCommand(
                    titulo: (string)body.titulo,
                    descricao: (string)body.descricao,
                    preco: decimal.Parse((body.preco).ToString(), ci),
                    tempoGastoEmMinutos: (int)body.tempoGastoEmMinutos,
                    idEstabelecimento: (Guid)body.idEstabelecimento
                );

            var tipoDeServico = _tipoDeServicoApp.Cadastrar(tipoDeServicoCommand);

            return CreateResponse(HttpStatusCode.Created, tipoDeServico);
        }

        [HttpPut]
        [Authorize(Roles = "Gerente")]
        [Route("api/tiposdeservico/{id:guid}")]
        public Task<HttpResponseMessage> Put(Guid id, [FromBody]dynamic body)
        {
            var ci = CultureInfo.InvariantCulture.Clone() as CultureInfo;
            ci.NumberFormat.NumberDecimalSeparator = ",";

            var tipoDeServicoCommand = new TipoDeServicoCommand(
                    titulo: (string)body.titulo,
                    descricao: (string)body.descricao,
                    preco: decimal.Parse((body.preco).ToString(), ci),
                    tempoGastoEmMinutos: (int)body.tempoGastoEmMinutos,
                    idEstabelecimento: (Guid)body.idEstabelecimento
                );

            tipoDeServicoCommand.IdTipoDeServico = id;

            var tipoDeServico = _tipoDeServicoApp.Atualizar(tipoDeServicoCommand);

            return CreateResponse(HttpStatusCode.OK, tipoDeServico);
        }

        [HttpDelete]
        [Authorize(Roles = "Gerente")]
        [Route("api/tiposdeservico/{id:guid}")]
        public Task<HttpResponseMessage> Delete(Guid id)
        {
            var tipoDeServico = _tipoDeServicoApp.Remover(id);

            return CreateResponse(HttpStatusCode.OK, tipoDeServico);
        }
    }
}
