using System;
using System.Collections.Generic;

namespace SBP.Domain.Entidades
{
    public class Estado
    {
        protected Estado()
        {
        }

        public Estado(string uf, string nome, Guid? idEstado)
        {
            IdEstado = idEstado == null ? Guid.NewGuid() : idEstado.Value;

            UF = uf;
            Nome = nome;

            ListaDeCidades = new List<Cidade>();
            ListaDeEnderecos = new List<Endereco>();
            ListaDeEnderecosJuridicos = new List<EnderecoJuridico>();
        }

        public Estado(Guid estadoId)
        {
            IdEstado = estadoId;
        }

        #region "Propriedades"

        public Guid IdEstado { get; private set; }

        public string Nome { get; private set; }

        public string UF { get; private set; }

        public ICollection<Cidade> ListaDeCidades { get; set; }

        public ICollection<Endereco> ListaDeEnderecos { get; set; }

        public ICollection<EnderecoJuridico> ListaDeEnderecosJuridicos { get; set; }

        #endregion
    }
}
