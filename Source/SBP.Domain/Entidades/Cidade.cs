using System;
using System.Collections.Generic;

namespace SBP.Domain.Entidades
{
    public class Cidade
    {
        protected Cidade()
        {
        }
        
        public Cidade(string nome, Guid estadoId, Guid? idCidade)
        {
            IdCidade = idCidade == null ? Guid.NewGuid() : idCidade.Value;

            Nome = nome;
            EstadoId = estadoId;

            ListaDeEnderecos = new List<Endereco>();
            ListaDeEnderecosJuridicos = new List<EnderecoJuridico>();
        }

        #region "Propriedades"

        public Guid IdCidade { get; private set; }

        public Guid EstadoId { get; private set; }

        public Estado Estado { get; private set; }

        public string Nome { get; private set; }

        public ICollection<Endereco> ListaDeEnderecos { get; set; }

        public ICollection<EnderecoJuridico> ListaDeEnderecosJuridicos { get; set; }

        #endregion
    }
}
