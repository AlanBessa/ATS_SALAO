using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP.Application.Command
{
    public class TipoDeServicoCommand
    {
        public TipoDeServicoCommand(string titulo, string descricao, decimal preco, int tempoGastoEmMinutos, Guid? idEstabelecimento)
        {
            Titulo = titulo;
            Descricao = descricao;
            Preco = preco;
            TempoGastoEmMinutos = tempoGastoEmMinutos;
            EstabelecimentoId = idEstabelecimento;
        }

        public Guid? IdTipoDeServico { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }

        public int TempoGastoEmMinutos { get; set; }

        public Guid? EstabelecimentoId { get; set; }

        public EstabelecimentoCommand Estabelecimento { get; set; }
    }
}
