using SBP.Domain.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SBP.Infra.Data.EntityConfig
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            // Chave primaria
            HasKey(u => u.IdPessoa);

            //Propriedades
            Property(u => u.IdPessoa)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(u => u.Senha)
                .HasMaxLength(100)
                .IsRequired();

            Property(u => u.Email.Endereco)
                .HasMaxLength(80)
                .IsRequired();
            
            Property(u => u.Perfil)
                .IsRequired();

            Property(c => c.DataDeCadastro)
                .HasColumnType("DateTime2")
                .IsRequired();

            Property(c => c.DataDeAtualizacao)
                .HasColumnType("DateTime2");

            Property(c => c.DataDoUltimoLogin)
                .HasColumnType("DateTime2");

            Property(u => u.EstaAtivo)
                .IsRequired();

            //Mapeamento
            ToTable("TB_USUARIO");

            Ignore(c => c.ValidationResult);

            //Relacionamentos
            //HasRequired(u => u.Pessoa)
            //    .WithOptional(p => p.Usuario);
        }
    }
}
