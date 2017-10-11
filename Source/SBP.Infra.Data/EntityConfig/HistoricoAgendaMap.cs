using SBP.Domain.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SBP.Infra.Data.EntityConfig
{
    public class HistoricoAgendaMap : EntityTypeConfiguration<HistoricoAgenda>
    {
        public HistoricoAgendaMap()
        {
            // Chave primaria
            HasKey(hag => hag.IdHistoricoAgenda);

            //Propriedades
            Property(hag => hag.IdHistoricoAgenda)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(hag => hag.DataDoAgendamento)
                .HasColumnType("DateTime2")
                .IsRequired();

            Property(hag => hag.DataDeCadastro)
                .HasColumnType("DateTime2")
                .IsRequired();

            Property(hag => hag.Status)
                .IsRequired();

            //Mapeamento
            ToTable("TB_HISTORICO_AGENDA");

            //Relacionamentos
            HasRequired(hag => hag.Cliente)
                .WithMany(c => c.ListaDeHistoricoDeAgendamentos)
                .HasForeignKey(hag => hag.ClienteId);

            HasRequired(hag => hag.Funcionario)
                .WithMany(f => f.ListaDeHistoricoDeAgendamentos)
                .HasForeignKey(hag => hag.FuncionarioId);

            HasRequired(hag => hag.TipoDeServico)
                .WithMany(ts => ts.ListaDeHistoricoDeAgendamentos)
                .HasForeignKey(hag => hag.TipoDeServicoId);
        }
    }
}
