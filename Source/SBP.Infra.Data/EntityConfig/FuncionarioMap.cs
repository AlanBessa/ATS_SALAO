using SBP.Domain.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SBP.Infra.Data.EntityConfig
{
    public class FuncionarioMap : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioMap()
        {
            // Chave primaria
            HasKey(f => f.IdPessoa);

            //Propriedades
            Property(f => f.IdPessoa)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(f => f.EstaAtivo)
                .IsRequired();
            
            Property(f => f.DataDeCadastro)
                .HasColumnType("DateTime2")
                .IsRequired();

            Property(f => f.DataDeAtualizacao)
                .HasColumnType("DateTime2");

            //Mapeamento
            ToTable("TB_FUNCIONARIO");

            //Relacionamentos
            HasMany(f => f.ListaDeAgendamentos)
                .WithRequired(ag => ag.Funcionario);

            HasMany(f => f.ListaDeAtendimentos)
                .WithRequired(at => at.Funcionario);

            HasRequired(f => f.Estabelecimento)
                .WithMany(estab => estab.ListaDeFuncionarios)
                .HasForeignKey(f => f.EstabelecimentoId);
        }
    }
}
