using SBP.Domain.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SBP.Infra.Data.EntityConfig
{
    public class EstabelecimentoMap : EntityTypeConfiguration<Estabelecimento>
    {
        public EstabelecimentoMap()
        {
            // Chave primaria
            HasKey(estab => estab.IdPessoaJuridica);

            //Propriedades
            Property(estab => estab.IdPessoaJuridica)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(estab => estab.EstaAtivo)
                .IsRequired();

            Property(estab => estab.Descricao)
                .HasMaxLength(500)
                .IsRequired();

            Property(estab => estab.DataDeCadastro)
                .HasColumnType("DateTime2")
                .IsRequired();

            Property(estab => estab.DataDeAtualizacao)
                .HasColumnType("DateTime2");

            //Mapeamento
            ToTable("TB_ESTABELECIMENTO");

            //Relacionamentos
            HasMany(estab => estab.ListaDeFuncionarios)
                .WithRequired(f => f.Estabelecimento);

            HasMany(estab => estab.ListaDeTiposDeServico)
                .WithRequired(ts => ts.Estabelecimento);

            HasMany(estab => estab.ListaDeAgendamento)
                .WithRequired(ag => ag.Estabelecimento);

            HasMany(estab => estab.ListaDeAtendimentos)
                .WithRequired(at => at.Estabelecimento);
        }
    }
}
