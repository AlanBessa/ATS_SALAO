using SBP.Application.Command;
using SBP.Application.Interfaces;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SBP.Presentation.Api.Controllers
{
    public class EstabelecimentoController : BaseController
    {
        private readonly IEstabelecimentoApp _estabelecimentoApp;

        public EstabelecimentoController(IEstabelecimentoApp estabelecimentoApp)
        {
            _estabelecimentoApp = estabelecimentoApp;
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdministrador")]
        [Route("api/estabelecimentos/{id:guid}")]
        public Task<HttpResponseMessage> Get(Guid id)
        {
            var estabelecimento = _estabelecimentoApp.ObterPorId(id);

            if (estabelecimento == null)
                return CreateResponse(HttpStatusCode.InternalServerError, estabelecimento);

            return CreateResponse(HttpStatusCode.OK, estabelecimento);
        }

        //[HttpGet]
        //[Authorize(Roles = "usuario")]
        //[Route("api/estabelecimentos")]
        //public Task<HttpResponseMessage> Get()
        //{
        //    var estabelecimentos = _estabelecimentoApp.ObterTodos();

        //    if (estabelecimentos == null)
        //        return CreateResponse(HttpStatusCode.InternalServerError, estabelecimentos);

        //    return CreateResponse(HttpStatusCode.OK, estabelecimentos);
        //}

        [HttpGet]
        [Authorize(Roles = "SuperAdministrador")]
        [Route("api/estabelecimentos/status/{ativo:bool}")]
        public Task<HttpResponseMessage> Get(bool ativo)
        {
            var estabelecimentos = _estabelecimentoApp.ObterTodosPorStatus(ativo);

            if (estabelecimentos == null)
                return CreateResponse(HttpStatusCode.InternalServerError, estabelecimentos);

            return CreateResponse(HttpStatusCode.OK, estabelecimentos);
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdministrador")]
        [Route("api/estabelecimentos")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var estabelecimentoCommand = new EstabelecimentoCommand(
                    razaoSocial: (string)body.estabelecimento.razaoSocial,
                    nomeFantasia: (string)body.estabelecimento.nomeFantasia,
                    email: (string)body.estabelecimento.email,
                    cnpj: (string)body.estabelecimento.cnpj,
                    telefone: (string)body.estabelecimento.telefone,
                    logo: (string)body.estabelecimento.logo,
                    descricao: (string)body.estabelecimento.descricao
                );
            var enderecoJuridicoCommand = new EnderecoJuridicoCommand(
                    logradouro: (string)body.estabelecimento.logradouro,
                    numero: (string)body.estabelecimento.numero,
                    complemento: (string)body.estabelecimento.complemento,
                    bairro: (string)body.estabelecimento.bairro,
                    cep: (string)body.estabelecimento.cep,
                    idCidade: (Guid)body.estabelecimento.idCidade,
                    idEstado: (Guid)body.estabelecimento.idEstado
                );
            var funcionarioCommand = new FuncionarioCommand(
                    nome: (string)body.nome,
                    cpf: (string)body.cpf,
                    celular: (string)body.celular,
                    email: (string)body.email,
                    funcao: (string)body.funcao,
                    idEstabelecimento: null,
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
            var usuarioCommand = new UsuarioCommand(
                    email: (string)body.usuario.email,
                    senha: (string)body.usuario.confirmarSenha,
                    perfil: (int)body.usuario.perfil,
                    estaAtivo: (bool)body.usuario.estaAtivo,
                    idPessoa: null
                );

            estabelecimentoCommand.EnderecoJuridico = enderecoJuridicoCommand;
            funcionarioCommand.Endereco = enderecoCommand;
            funcionarioCommand.Estabelecimento = estabelecimentoCommand;
            funcionarioCommand.Usuario = usuarioCommand;

            var estabelecimento = _estabelecimentoApp.Cadastrar(funcionarioCommand);

            return CreateResponse(HttpStatusCode.Created, estabelecimento);
        }

        [HttpPut]
        [Authorize(Roles = "SuperAdministrador")]
        [Route("api/estabelecimentos/{id:guid}")]
        public Task<HttpResponseMessage> Put(Guid id, [FromBody]dynamic body)
        {
            var estabelecimentoCommand = new EstabelecimentoCommand(
                    razaoSocial: (string)body.razaoSocial,
                    nomeFantasia: (string)body.nomeFantasia,
                    email: (string)body.email,
                    cnpj: (string)body.cnpj,
                    telefone: (string)body.telefone,
                    logo: (string)body.logo,
                    descricao: (string)body.descricao
                );
            var enderecoJuridicoCommand = new EnderecoJuridicoCommand(
                    logradouro: (string)body.enderecoJuridico.logradouro,
                    numero: (string)body.enderecoJuridico.numero,
                    complemento: (string)body.enderecoJuridico.complemento,
                    bairro: (string)body.enderecoJuridico.bairro,
                    cep: (string)body.enderecoJuridico.cep,
                    idCidade: (Guid)body.enderecoJuridico.cidadeId,
                    idEstado: (Guid)body.enderecoJuridico.estadoId
                );
            estabelecimentoCommand.EnderecoJuridico = enderecoJuridicoCommand;
            estabelecimentoCommand.IdPessoaJuridica = id;

            var estabelecimento = _estabelecimentoApp.Atualizar(estabelecimentoCommand);

            return CreateResponse(HttpStatusCode.OK, estabelecimento);
        }

        [HttpPut]
        [Authorize(Roles = "SuperAdministrador")]
        [Route("api/estabelecimentos/{id:guid}/ativo/{status:bool}")]
        public Task<HttpResponseMessage> Put(Guid id, bool status)
        {
            var estaAtivo = _estabelecimentoApp.AlterarStatusDeAtivacao(id, status);

            return CreateResponse(HttpStatusCode.OK, estaAtivo);
        }
    }
}
