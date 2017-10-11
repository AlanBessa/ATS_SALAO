using SBP.Domain.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SBP.Infra.Data.EntityConfig
{
    public class TipoDeServicoMap : EntityTypeConfiguration<TipoDeServico>
    {
        public TipoDeServicoMap()
        {
            // Chave primaria
            HasKey(ts => ts.IdTipoDeServico);

            //Propriedades
            Property(ts => ts.IdTipoDeServico)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(ts => ts.Titulo)
                .HasMaxLength(50)
                .IsRequired();

            Property(ts => ts.Descricao)
                .HasMaxLength(500);

            Property(ts => ts.DataDeCadastro)
                .HasColumnType("DateTime2")
                .IsRequired();

            Property(ts => ts.DataDeAtualizacao)
                .HasColumnType("DateTime2");

            Property(ts => ts.Preco);

            Property(ts => ts.TempoGastoEmMinutos);

            //Mapeamento
            ToTable("TB_TIPO_SERVICO");

            //Relacionamentos
            HasMany(ts => ts.ListaDeAgendamentos)
                .WithRequired(ag => ag.TipoDeServico);

            HasMany(ts => ts.ListaDeHistoricoDeAgendamentos)
                .WithRequired(hag => hag.TipoDeServico);

            HasMany(ts => ts.ListaDeAtendimentos)
                .WithRequired(at => at.TipoDeServico);

            HasRequired(ts => ts.Estabelecimento)
                .WithMany(estab => estab.ListaDeTiposDeServico)
                .HasForeignKey(ts => ts.EstabelecimentoId);
        }
    }
}
