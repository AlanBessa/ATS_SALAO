using System;

namespace SBP.Application.Command
{
    public class EnderecoJuridicoCommand
    {
        public EnderecoJuridicoCommand(string logradouro, string numero, string complemento, string bairro, string cep, Guid idCidade, Guid idEstado)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cep = cep;
            CidadeId = idCidade;
            EstadoId = idEstado;
        }

        public Guid? IdEndereco { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public Guid CidadeId { get; set; }

        public CidadeCommand Cidade { get; set; }

        public Guid EstadoId { get; set; }

        public EstadoCommand Estado { get; set; }

        public string Cep { get; set; }
    }
}
