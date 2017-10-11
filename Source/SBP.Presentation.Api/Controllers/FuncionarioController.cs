using SBP.Application.Command;
using SBP.Application.Interfaces;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SBP.Presentation.Api.Controllers
{
    public class FuncionarioController : BaseController
    {
        private readonly IFuncionarioApp _funcionarioApp;

        public FuncionarioController(IFuncionarioApp funcionarioApp)
        {
            _funcionarioApp = funcionarioApp;
        }

        [HttpGet]
        [Authorize(Roles = "Gerente, SuperAdministrador")]
        [Route("api/funcionarios/{id:guid}")]
        public Task<HttpResponseMessage> Get(Guid id)
        {
            var funcionario = _funcionarioApp.ObterPorId(id);

            if (funcionario == null)
                return CreateResponse(HttpStatusCode.InternalServerError, funcionario);

            return CreateResponse(HttpStatusCode.OK, funcionario);
        }

        //[HttpGet]
        //[Authorize(Roles = "usuario")]
        //[Route("api/funcionarios")]
        //public Task<HttpResponseMessage> Get()
        //{
        //    var funcionarios = _funcionarioApp.ObterTodos();

        //    if (funcionarios == null)
        //        return CreateResponse(HttpStatusCode.InternalServerError, funcionarios);

        //    return CreateResponse(HttpStatusCode.OK, funcionarios);
        //}

        [HttpGet]
        [Authorize(Roles = "Gerente")]
        [Route("api/funcionarios/estabelecimento/{id:guid}/status/{ativo:bool}")]
        public Task<HttpResponseMessage> ObterTodosAtivosPorEstabelecimento(Guid id, bool ativo)
        {
            var funcionarios = _funcionarioApp.ObterTodosPorEstabelecimentoEhStatus(id, ativo);

            if (funcionarios == null)
                return CreateResponse(HttpStatusCode.InternalServerError, funcionarios);

            return CreateResponse(HttpStatusCode.OK, funcionarios);
        }
        
        [HttpPost]
        [Authorize(Roles = "Gerente")]
        [Route("api/funcionarios")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var funcionarioCommand = new FuncionarioCommand(
                    nome: (string)body.nome,
                    cpf: (string)body.cpf,
                    celular: (string)body.celular,
                    email: (string)body.email,
                    funcao:(string)body.funcao,
                    idEstabelecimento: (Guid)body.estabelecimentoId,
                    imagem: (string)body.imagem
                );
            var enderecoCommand = new EnderecoCommand(
                    logradouro: (string)body.logradouro,
                    numero: (string)body.numero,
                    complemento: (string)body.complemento,
                    bairro: (string)body.bairro,
                    cep: (string)body.cep,
                    idCidade: (Guid)body.idCidade,
                    idEstado: (Guid)body.idEstado
                );
            funcionarioCommand.Endereco = enderecoCommand;

            var funcionario = _funcionarioApp.Cadastrar(funcionarioCommand);

            return CreateResponse(HttpStatusCode.Created, funcionario);
        }

        [HttpPut]
        [Authorize(Roles = "Gerente, SuperAdministrador")]
        [Route("api/funcionarios/{id:guid}")]
        public Task<HttpResponseMessage> Put(Guid id, [FromBody]dynamic body)
        {
            var funcionarioCommand = new FuncionarioCommand(
                    nome: (string)body.nome,
                    cpf: (string)body.cpf,
                    celular: (string)body.celular,
                    email: (string)body.email,
                    funcao: (string)body.funcao,
                    idEstabelecimento: (Guid)body.estabelecimentoId,
                    imagem: (string)body.imagem
                );
            var enderecoCommand = new EnderecoCommand(
                    logradouro: (string)body.endereco.logradouro,
                    numero: (string)body.endereco.numero,
                    complemento: (string)body.endereco.complemento,
                    bairro: (string)body.endereco.bairro,
                    cep: (string)body.endereco.cep,
                    idCidade: (Guid)body.endereco.cidadeId,
                    idEstado: (Guid)body.endereco.estadoId
                );
            funcionarioCommand.Endereco = enderecoCommand;
            funcionarioCommand.IdPessoa = id;

            var funcionario = _funcionarioApp.Atualizar(funcionarioCommand);
            
            return CreateResponse(HttpStatusCode.OK, funcionario);
        }

        [HttpPut]
        [Authorize(Roles = "Gerente")]
        [Route("api/funcionarios/{id:guid}/ativo/{status:bool}")]
        public Task<HttpResponseMessage> Put(Guid id, bool status)
        {
            var estaAtivo = _funcionarioApp.AlterarStatusDeAtivacao(id, status);

            return CreateResponse(HttpStatusCode.OK, estaAtivo);
        }
    }
}
