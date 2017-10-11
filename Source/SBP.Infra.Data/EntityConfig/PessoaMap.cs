using SBP.Domain.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SBP.Infra.Data.EntityConfig
{
    public class PessoaMap : EntityTypeConfiguration<Pessoa>
    {
        public PessoaMap()
        {
            // Chave primaria
            HasKey(p => p.IdPessoa);

            //Propriedades
            Property(p => p.IdPessoa)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Nome)
                .HasMaxLength(200)
                .IsRequired();

            Property(p => p.CPF.Codigo)
                .HasMaxLength(11)
                .IsRequired();

            Property(p => p.Celular.Numero)
                .HasMaxLength(11)
                .IsRequired();

            Property(p => p.Email.Endereco)
                .HasMaxLength(80);

            //Mapeamento
            ToTable("TB_PESSOA");

            Ignore(c => c.ValidationResult);

            //Relacionamentos
            HasOptional(p => p.Usuario)
                .WithRequired(u => u.Pessoa);

            HasMany(p => p.ListaDeEnderecos)
                .WithRequired(e => e.Pessoa);
        }
    }
}
