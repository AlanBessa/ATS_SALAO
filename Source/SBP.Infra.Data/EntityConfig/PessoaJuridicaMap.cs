using SBP.Domain.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SBP.Infra.Data.EntityConfig
{
    public class PessoaJuridicaMap : EntityTypeConfiguration<PessoaJuridica>
    {
        public PessoaJuridicaMap()
        {
            // Chave primaria
            HasKey(p => p.IdPessoaJuridica);

            //Propriedades
            Property(p => p.IdPessoaJuridica)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.RazaoSocial)
                .HasMaxLength(100)
                .IsRequired();

            Property(p => p.NomeFantasia)
                .HasMaxLength(100)
                .IsRequired();

            Property(p => p.CNPJ.Codigo)
                .HasMaxLength(14)
                .IsRequired();

            Property(p => p.Telefone.Numero)
                .HasMaxLength(11)
                .IsRequired();

            Property(p => p.Email.Endereco)
                .HasMaxLength(80);

            //Mapeamento
            ToTable("TB_PESSOA_JURIDICA");

            Ignore(c => c.ValidationResult);

            //Relacionamentos
            HasMany(p => p.ListaDeEnderecosJuridicos)
                .WithRequired(e => e.PessoaJuridica);
        }
    }
}
