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
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            // Chave primaria
            HasKey(c => c.IdPessoa);

            //Propriedades
            Property(c => c.IdPessoa)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); ;

            Property(c => c.DataDeNascimento)
                .HasColumnType("DateTime2")
                .IsRequired();

            Property(c => c.DataDeCadastro)
                .HasColumnType("DateTime2")
                .IsRequired();

            Property(c => c.DataDeAtualizacao)
                .HasColumnType("DateTime2");

            //Mapeamento
            ToTable("TB_CLIENTE");

            //Relacionamentos
            HasMany(c => c.ListaDeAgendamentos)
                .WithRequired(ag => ag.Cliente);

            HasMany(c => c.ListaDeHistoricoDeAgendamentos)
                .WithRequired(hag => hag.Cliente);

            HasMany(c => c.ListaDeAtendimentos)
                .WithRequired(at => at.Cliente);
        }
    }
}
