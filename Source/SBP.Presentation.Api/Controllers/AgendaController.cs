using SBP.Application.Command;
using SBP.Application.Interfaces;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SBP.Presentation.Api.Controllers
{
    public class AgendaController : BaseController
    {
        private readonly IAgendaApp _agendaApp;

        public AgendaController(IAgendaApp agendaApp)
        {
            _agendaApp = agendaApp;
        }

        //[HttpGet]
        //[Authorize(Roles = "usuario")]
        //[Route("api/agendas/{id:guid}")]
        //public Task<HttpResponseMessage> Get(Guid id)
        //{
        //    var agenda = _agendaApp.ObterPorId(id);

        //    if (agenda == null)
        //        return CreateResponse(HttpStatusCode.InternalServerError, agenda);

        //    return CreateResponse(HttpStatusCode.OK, agenda);
        //}

        //[HttpGet]
        //[Authorize(Roles = "usuario")]
        //[Route("api/agendas")]
        //public Task<HttpResponseMessage> Get()
        //{
        //    var agendas = _agendaApp.ObterTodos();

        //    if (agendas == null)
        //        return CreateResponse(HttpStatusCode.InternalServerError, agendas);

        //    return CreateResponse(HttpStatusCode.OK, agendas);
        //}
        
        [HttpPost]
        [Authorize(Roles = "Gerente, Funcionario")]
        [Route("api/agendas")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var agendaCommand = new AgendaCommand(
                    dataInicioDoAgendamento: (DateTime)body.startsAt,
                    idCliente: (Guid)body.clienteId,
                    idFuncionario: (Guid)body.funcionarioId,
                    idTipoDeServico: (Guid)body.tipoDeServicoId,
                    idEstabelecimento: (Guid)body.estabelecimentoId
                );

            var agenda = _agendaApp.Cadastrar(agendaCommand);

            return CreateResponse(HttpStatusCode.Created, agenda);
        }

        [HttpPut]
        [Authorize(Roles = "Gerente, Funcionario")]
        [Route("api/agendas/{id:guid}")]
        public Task<HttpResponseMessage> Put(Guid id, [FromBody]dynamic body)
        {
            var agendaCommand = new AgendaCommand(
                    dataInicioDoAgendamento: (DateTime)body.startsAt,
                    idCliente: (Guid)body.clienteId,
                    idFuncionario: (Guid)body.funcionarioId,
                    idTipoDeServico: (Guid)body.tipoDeServicoId,
                    idEstabelecimento: (Guid)body.estabelecimentoId
                );

            agendaCommand.IdAgenda = id;

            var agenda = _agendaApp.Atualizar(agendaCommand);

            return CreateResponse(HttpStatusCode.OK, agenda);
        }

        [HttpGet]
        [Authorize(Roles = "Gerente, Funcionario")]
        [Route("api/agendas/estabelecimento/{id:guid}")]
        public Task<HttpResponseMessage> ObterTodosPorEstabelecimento(Guid id)
        {
            var agendas = _agendaApp.ObterTodosPorEstabelecimento(id);

            if (agendas == null)
                return CreateResponse(HttpStatusCode.InternalServerError, agendas);

            return CreateResponse(HttpStatusCode.OK, agendas);
        }

        [HttpGet]
        [Authorize(Roles = "Gerente, Funcionario")]
        [Route("api/agendas/estabelecimento/{estabelecimentoId:guid}/funcionario/{funcionarioId:guid}")]
        public Task<HttpResponseMessage> ObterTodosPor(Guid estabelecimentoId, Guid funcionarioId)
        {
            var agendas = _agendaApp.ObterTodosPor(estabelecimentoId, funcionarioId);

            if (agendas == null)
                return CreateResponse(HttpStatusCode.InternalServerError, agendas);

            return CreateResponse(HttpStatusCode.OK, agendas);
        }

        //[HttpPut]
        //[Route("api/agendas/{id:guid}/ativo/{status:bool}")]
        //public Task<HttpResponseMessage> Put(Guid id, bool status)
        //{
        //    var estaAtivo = _agendaApp.AlterarStatusDeAtivacao(id, status);

        //    return CreateResponse(HttpStatusCode.OK, estaAtivo);
        //}
    }
}
