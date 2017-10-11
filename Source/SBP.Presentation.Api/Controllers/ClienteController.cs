using SBP.Application.Command;
using SBP.Application.Interfaces;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SBP.Presentation.Api.Controllers
{
    public class ClienteController : BaseController
    {
        private readonly IClienteApp _clienteApp;

        public ClienteController(IClienteApp clienteApp)
        {
            _clienteApp = clienteApp;
        }

        [HttpGet]
        [Authorize(Roles = "Gerente")]
        [Route("api/clientes/{id:guid}")]
        public Task<HttpResponseMessage> Get(Guid id)
        {
            var cliente = _clienteApp.ObterPorId(id);

            if (cliente == null)
                return CreateResponse(HttpStatusCode.InternalServerError, cliente);

            return CreateResponse(HttpStatusCode.OK, cliente);
        }

        [HttpGet]
        [Authorize(Roles = "Gerente")]
        [Route("api/clientes")]
        public Task<HttpResponseMessage> Get()
        {
            var clientes = _clienteApp.ObterTodos();

            if (clientes == null)
                return CreateResponse(HttpStatusCode.InternalServerError, clientes);

            return CreateResponse(HttpStatusCode.OK, clientes);
        }

        [HttpPost]
        [Authorize(Roles = "Gerente")]
        [Route("api/clientes")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            //Entradas de dados devem ser revistas quando for criado o Frontend

            var clienteCommand = new ClienteCommand(
                    nome: (string)body.nome,
                    cpf: (string)body.cpf,
                    celular: (string)body.celular,
                    email: (string)body.email,
                    dataDeNascimento: (DateTime?)body.dataDeNascimento,
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
            clienteCommand.Endereco = enderecoCommand;

            var cliente = _clienteApp.Cadastrar(clienteCommand);

            return CreateResponse(HttpStatusCode.Created, cliente);
        }

        [HttpPut]
        [Authorize(Roles = "Gerente")]
        [Route("api/clientes/{id:guid}")]
        public Task<HttpResponseMessage> Put(Guid id, [FromBody]dynamic body)
        {
            //Entradas de dados devem ser revistas quando for criado o Frontend

            var clienteCommand = new ClienteCommand(
                    nome: (string)body.nome,
                    cpf: (string)body.cpf,
                    celular: (string)body.celular,
                    email: (string)body.email,
                    dataDeNascimento: (DateTime?)body.dataDeNascimento,
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
            clienteCommand.Endereco = enderecoCommand;
            clienteCommand.IdPessoa = id;

            var cliente = _clienteApp.Atualizar(clienteCommand);

            return CreateResponse(HttpStatusCode.OK, cliente);
        }

        [HttpGet]
        [Authorize(Roles = "Gerente")]
        [Route("api/clientes/busca/{cpf}")]
        public Task<HttpResponseMessage> ListarClientesPorCPF(string cpf)
        {
            var cliente = _clienteApp.ObterPorCPF(cpf);

            if (cliente == null)
                return CreateResponse(HttpStatusCode.InternalServerError, cliente);

            return CreateResponse(HttpStatusCode.OK, cliente);
        }
    }
}
