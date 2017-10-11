using SBP.Domain.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SBP.Infra.Data.EntityConfig
{
    public class AgendaMap : EntityTypeConfiguration<Agenda>
    {
        public AgendaMap()
        {
            // Chave primaria
            HasKey(ag => ag.IdAgenda);

            //Propriedades
            Property(ag => ag.IdAgenda)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(ag => ag.DataInicioDoAgendamento)
                .HasColumnType("DateTime2")
                .IsRequired();

            Property(ag => ag.DataFimDoAgendamento)
                .HasColumnType("DateTime2")
                .IsRequired();

            Property(ag => ag.Status)
                .IsRequired();
            
            //Mapeamento
            ToTable("TB_AGENDA");

            //Relacionamentos
            HasRequired(ag => ag.Cliente)
                .WithMany(c => c.ListaDeAgendamentos)
                .HasForeignKey(ag => ag.ClienteId);

            HasRequired(ag => ag.Funcionario)
                .WithMany(f => f.ListaDeAgendamentos)
                .HasForeignKey(ag => ag.FuncionarioId);

            HasRequired(ag => ag.TipoDeServico)
                .WithMany(ts => ts.ListaDeAgendamentos)
                .HasForeignKey(ag => ag.TipoDeServicoId);

            HasRequired(ag => ag.Estabelecimento)
                .WithMany(estab => estab.ListaDeAgendamento)
                .HasForeignKey(ag => ag.EstabelecimentoId);
        }
    }
}
