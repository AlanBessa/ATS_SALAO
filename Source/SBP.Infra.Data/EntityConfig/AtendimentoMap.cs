using SBP.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP.Infra.Data.EntityConfig
{
    public class AtendimentoMap : EntityTypeConfiguration<Atendimento>
    {
        public AtendimentoMap()
        {
            // Chave primaria
            HasKey(at => at.IdAtendimento);

            //Propriedades
            Property(at => at.IdAtendimento)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); ;

            Property(at => at.DataHoraInicio)
                .HasColumnType("DateTime2")
                .IsRequired();

            Property(at => at.DataHoraFim)
                .HasColumnType("DateTime2");

            Property(at => at.Observacao)
                .HasMaxLength(500);

            Property(at => at.StatusPagamento)
                .IsRequired();

            Property(at => at.ValorPago);

            Property(at => at.Status)
                .IsRequired();

            //Mapeamento
            ToTable("TB_ATENDIMENTO");

            //Relacionamentos
            HasRequired(at => at.Cliente)
                .WithMany(c => c.ListaDeAtendimentos)
                .HasForeignKey(at => at.ClienteId);

            HasRequired(at => at.Funcionario)
                .WithMany(f => f.ListaDeAtendimentos)
                .HasForeignKey(at => at.FuncionarioId);

            HasRequired(at => at.TipoDeServico)
                .WithMany(ts => ts.ListaDeAtendimentos)
                .HasForeignKey(at => at.TipoDeServicoId);

            HasRequired(at => at.Estabelecimento)
                .WithMany(estab => estab.ListaDeAtendimentos)
                .HasForeignKey(at => at.EstabelecimentoId);
        }
    }
}
