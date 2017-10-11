using SBP.Domain.Scopes;
using SBP.Domain.SharedKernel.Helpers;
using SBP.Domain.SharedKernel.ValueObjects;
using System;

namespace SBP.Domain.Entidades
{
    public class Endereco
    {
        protected Endereco()
        {
        }

        public Endereco(string logradouro, string complemento, string numero, string bairro,
            Guid cidadeId, Guid estadoId, string cep)
        {
            IdEndereco = Guid.NewGuid();
            DefinirCep(cep);
            DefinirBairro(bairro);
            DefinirCidade(cidadeId);
            DefinirEstado(estadoId);
            DefinirComplemento(complemento);
            DefinirLogradouro(logradouro);
            DefinirNumero(numero);            
        }

        #region "Propriedades"

        public Guid IdEndereco { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public Guid PessoaId { get; set; }

        public Pessoa Pessoa { get; set; }

        public Guid CidadeId { get; private set; }

        public Cidade Cidade { get; private set; }

        public Guid EstadoId { get; private set; }

        public Estado Estado { get; private set; }

        public CEP Cep { get; set; }

        #endregion

        #region "Metodos"

        public void DefinirCep(string cep)
        {
            var tempCep = TextoHelper.GetNumeros(cep);

            if (this.DefinirCEPScopeEhValido(tempCep))
                Cep = new CEP(tempCep);
        }

        public void DefinirComplemento(string complemento)
        {
            if (string.IsNullOrEmpty(complemento))
                complemento = "";
            Complemento = TextoHelper.ToTitleCase(complemento);
        }

        public void DefinirLogradouro(string logradouro)
        {
            if (this.DefinirLogradouroScopeEhValido(logradouro))
                Logradouro = TextoHelper.ToTitleCase(logradouro);
        }

        public void DefinirNumero(string numero)
        {
            if (this.DefinirNumeroScopeEhValido(numero))
                Numero = numero;
        }

        public void DefinirBairro(string bairro)
        {
            if (this.DefinirBairroScopeEhValido(bairro))
                Bairro = TextoHelper.ToTitleCase(bairro);
        }

        public void DefinirCidade(Guid cidadeId)
        {
            if (this.DefinirCidadeScopeEhValido(cidadeId))
                CidadeId = cidadeId;
        }

        public void DefinirCidade(Cidade cidade)
        {
            if (this.DefinirCidadeScopeEhValido(cidade))
                Cidade = cidade;
        }

        public void DefinirEstado(Guid estadoId)
        {
            if (this.DefinirEstadoScopeEhValido(estadoId))
                EstadoId = estadoId;
        }

        public void DefinirEstado(Estado estado)
        {
            if (this.DefinirEstadoScopeEhValido(estado))
                Estado = estado;
        }

        public void DefinirObjetoCidade(Cidade cidade)
        {
            Cidade = cidade;
        }

        public void DefinirObjetoEstado(Estado estado)
        {
            Estado = estado;
        }

        public override string ToString()
        {
            return Logradouro + ", " + Numero + " - " + Complemento + " <br /> " + Bairro + " - " + Cidade.Nome + "/" + Estado.Nome;
        }

        public void AtualizarDados(string logradouro, string numero, string complemento, string bairro,
            Guid cidadeId, Guid estadoId, string cep)
        {
            DefinirLogradouro(logradouro);
            DefinirNumero(numero);
            Complemento = complemento;
            DefinirBairro(bairro);
            DefinirCidade(cidadeId);
            DefinirEstado(estadoId);
            DefinirCep(cep);
        }

        #endregion  
    }
}
