namespace SBP.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_AGENDA",
                c => new
                    {
                        IdAgenda = c.Guid(nullable: false, identity: true),
                        DataInicioDoAgendamento = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DataFimDoAgendamento = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ClienteId = c.Guid(nullable: false),
                        FuncionarioId = c.Guid(nullable: false),
                        TipoDeServicoId = c.Guid(nullable: false),
                        EstabelecimentoId = c.Guid(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdAgenda)
                .ForeignKey("dbo.TB_CLIENTE", t => t.ClienteId)
                .ForeignKey("dbo.TB_ESTABELECIMENTO", t => t.EstabelecimentoId)
                .ForeignKey("dbo.TB_FUNCIONARIO", t => t.FuncionarioId)
                .ForeignKey("dbo.TB_TIPO_SERVICO", t => t.TipoDeServicoId)
                .Index(t => t.ClienteId)
                .Index(t => t.FuncionarioId)
                .Index(t => t.TipoDeServicoId)
                .Index(t => t.EstabelecimentoId);
            
            CreateTable(
                "dbo.TB_PESSOA",
                c => new
                    {
                        IdPessoa = c.Guid(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 200, unicode: false),
                        CPF_Codigo = c.String(nullable: false, maxLength: 11, unicode: false),
                        Celular_Numero = c.String(nullable: false, maxLength: 11, unicode: false),
                        Email_Endereco = c.String(nullable: false, maxLength: 80, unicode: false),
                        Imagem = c.Binary(),
                    })
                .PrimaryKey(t => t.IdPessoa);
            
            CreateTable(
                "dbo.TB_ATENDIMENTO",
                c => new
                    {
                        IdAtendimento = c.Guid(nullable: false, identity: true),
                        DataHoraInicio = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DataHoraFim = c.DateTime(precision: 7, storeType: "datetime2"),
                        Observacao = c.String(maxLength: 500, unicode: false),
                        StatusPagamento = c.Int(nullable: false),
                        ValorPago = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        ClienteId = c.Guid(nullable: false),
                        FuncionarioId = c.Guid(nullable: false),
                        TipoDeServicoId = c.Guid(nullable: false),
                        EstabelecimentoId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.IdAtendimento)
                .ForeignKey("dbo.TB_CLIENTE", t => t.ClienteId)
                .ForeignKey("dbo.TB_ESTABELECIMENTO", t => t.EstabelecimentoId)
                .ForeignKey("dbo.TB_FUNCIONARIO", t => t.FuncionarioId)
                .ForeignKey("dbo.TB_TIPO_SERVICO", t => t.TipoDeServicoId)
                .Index(t => t.ClienteId)
                .Index(t => t.FuncionarioId)
                .Index(t => t.TipoDeServicoId)
                .Index(t => t.EstabelecimentoId);
            
            CreateTable(
                "dbo.TB_PESSOA_JURIDICA",
                c => new
                    {
                        IdPessoaJuridica = c.Guid(nullable: false, identity: true),
                        RazaoSocial = c.String(nullable: false, maxLength: 100, unicode: false),
                        NomeFantasia = c.String(nullable: false, maxLength: 100, unicode: false),
                        Email_Endereco = c.String(nullable: false, maxLength: 80, unicode: false),
                        CNPJ_Codigo = c.String(nullable: false, maxLength: 14, unicode: false),
                        Telefone_Numero = c.String(nullable: false, maxLength: 11, unicode: false),
                    })
                .PrimaryKey(t => t.IdPessoaJuridica);
            
            CreateTable(
                "dbo.TB_ENDERECO_JURIDICO",
                c => new
                    {
                        IdEndereco = c.Guid(nullable: false, identity: true),
                        Logradouro = c.String(nullable: false, maxLength: 200, unicode: false),
                        Numero = c.String(nullable: false, maxLength: 10, unicode: false),
                        Complemento = c.String(maxLength: 200, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 80, unicode: false),
                        PessoaJuridicaId = c.Guid(nullable: false),
                        CidadeId = c.Guid(nullable: false),
                        EstadoId = c.Guid(nullable: false),
                        Cep_CepCod = c.String(nullable: false, maxLength: 8, unicode: false),
                    })
                .PrimaryKey(t => t.IdEndereco)
                .ForeignKey("dbo.TB_CIDADE", t => t.CidadeId)
                .ForeignKey("dbo.TB_ESTADO", t => t.EstadoId)
                .ForeignKey("dbo.TB_PESSOA_JURIDICA", t => t.PessoaJuridicaId)
                .Index(t => t.PessoaJuridicaId)
                .Index(t => t.CidadeId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.TB_CIDADE",
                c => new
                    {
                        IdCidade = c.Guid(nullable: false, identity: true),
                        EstadoId = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 60, unicode: false),
                    })
                .PrimaryKey(t => t.IdCidade)
                .ForeignKey("dbo.TB_ESTADO", t => t.EstadoId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.TB_ESTADO",
                c => new
                    {
                        IdEstado = c.Guid(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        UF = c.String(nullable: false, maxLength: 2, unicode: false),
                    })
                .PrimaryKey(t => t.IdEstado);
            
            CreateTable(
                "dbo.TB_ENDERECO",
                c => new
                    {
                        IdEndereco = c.Guid(nullable: false, identity: true),
                        Logradouro = c.String(nullable: false, maxLength: 200, unicode: false),
                        Numero = c.String(nullable: false, maxLength: 10, unicode: false),
                        Complemento = c.String(maxLength: 200, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 80, unicode: false),
                        PessoaId = c.Guid(nullable: false),
                        CidadeId = c.Guid(nullable: false),
                        EstadoId = c.Guid(nullable: false),
                        Cep_CepCod = c.String(nullable: false, maxLength: 8, unicode: false),
                    })
                .PrimaryKey(t => t.IdEndereco)
                .ForeignKey("dbo.TB_ESTADO", t => t.EstadoId)
                .ForeignKey("dbo.TB_PESSOA", t => t.PessoaId)
                .ForeignKey("dbo.TB_CIDADE", t => t.CidadeId)
                .Index(t => t.PessoaId)
                .Index(t => t.CidadeId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.TB_USUARIO",
                c => new
                    {
                        IdPessoa = c.Guid(nullable: false),
                        Email_Endereco = c.String(nullable: false, maxLength: 80, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 100, unicode: false),
                        Perfil = c.Int(nullable: false),
                        DataDeCadastro = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DataDeAtualizacao = c.DateTime(precision: 7, storeType: "datetime2"),
                        DataDoUltimoLogin = c.DateTime(precision: 7, storeType: "datetime2"),
                        EstaAtivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdPessoa)
                .ForeignKey("dbo.TB_PESSOA", t => t.IdPessoa)
                .Index(t => t.IdPessoa);
            
            CreateTable(
                "dbo.TB_HISTORICO_AGENDA",
                c => new
                    {
                        IdHistoricoAgenda = c.Guid(nullable: false, identity: true),
                        DataDoAgendamento = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DataDeCadastro = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ClienteId = c.Guid(nullable: false),
                        FuncionarioId = c.Guid(nullable: false),
                        TipoDeServicoId = c.Guid(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdHistoricoAgenda)
                .ForeignKey("dbo.TB_FUNCIONARIO", t => t.FuncionarioId)
                .ForeignKey("dbo.TB_TIPO_SERVICO", t => t.TipoDeServicoId)
                .ForeignKey("dbo.TB_CLIENTE", t => t.ClienteId)
                .Index(t => t.ClienteId)
                .Index(t => t.FuncionarioId)
                .Index(t => t.TipoDeServicoId);
            
            CreateTable(
                "dbo.TB_TIPO_SERVICO",
                c => new
                    {
                        IdTipoDeServico = c.Guid(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 50, unicode: false),
                        Descricao = c.String(maxLength: 500, unicode: false),
                        DataDeCadastro = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DataDeAtualizacao = c.DateTime(precision: 7, storeType: "datetime2"),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TempoGastoEmMinutos = c.Int(nullable: false),
                        EstabelecimentoId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.IdTipoDeServico)
                .ForeignKey("dbo.TB_ESTABELECIMENTO", t => t.EstabelecimentoId)
                .Index(t => t.EstabelecimentoId);
            
            CreateTable(
                "dbo.TB_CLIENTE",
                c => new
                    {
                        IdPessoa = c.Guid(nullable: false),
                        DataDeNascimento = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DataDeCadastro = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DataDeAtualizacao = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.IdPessoa)
                .ForeignKey("dbo.TB_PESSOA", t => t.IdPessoa)
                .Index(t => t.IdPessoa);
            
            CreateTable(
                "dbo.TB_ESTABELECIMENTO",
                c => new
                    {
                        IdPessoaJuridica = c.Guid(nullable: false),
                        Logo = c.Binary(),
                        EstaAtivo = c.Boolean(nullable: false),
                        Descricao = c.String(nullable: false, maxLength: 500, unicode: false),
                        DataDeCadastro = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DataDeAtualizacao = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.IdPessoaJuridica)
                .ForeignKey("dbo.TB_PESSOA_JURIDICA", t => t.IdPessoaJuridica)
                .Index(t => t.IdPessoaJuridica);
            
            CreateTable(
                "dbo.TB_FUNCIONARIO",
                c => new
                    {
                        IdPessoa = c.Guid(nullable: false),
                        EstaAtivo = c.Boolean(nullable: false),
                        Funcao = c.String(maxLength: 8000, unicode: false),
                        DataDeCadastro = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DataDeAtualizacao = c.DateTime(precision: 7, storeType: "datetime2"),
                        EstabelecimentoId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.IdPessoa)
                .ForeignKey("dbo.TB_PESSOA", t => t.IdPessoa)
                .ForeignKey("dbo.TB_ESTABELECIMENTO", t => t.EstabelecimentoId)
                .Index(t => t.IdPessoa)
                .Index(t => t.EstabelecimentoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_FUNCIONARIO", "EstabelecimentoId", "dbo.TB_ESTABELECIMENTO");
            DropForeignKey("dbo.TB_FUNCIONARIO", "IdPessoa", "dbo.TB_PESSOA");
            DropForeignKey("dbo.TB_ESTABELECIMENTO", "IdPessoaJuridica", "dbo.TB_PESSOA_JURIDICA");
            DropForeignKey("dbo.TB_CLIENTE", "IdPessoa", "dbo.TB_PESSOA");
            DropForeignKey("dbo.TB_AGENDA", "TipoDeServicoId", "dbo.TB_TIPO_SERVICO");
            DropForeignKey("dbo.TB_AGENDA", "FuncionarioId", "dbo.TB_FUNCIONARIO");
            DropForeignKey("dbo.TB_AGENDA", "EstabelecimentoId", "dbo.TB_ESTABELECIMENTO");
            DropForeignKey("dbo.TB_AGENDA", "ClienteId", "dbo.TB_CLIENTE");
            DropForeignKey("dbo.TB_HISTORICO_AGENDA", "ClienteId", "dbo.TB_CLIENTE");
            DropForeignKey("dbo.TB_ATENDIMENTO", "TipoDeServicoId", "dbo.TB_TIPO_SERVICO");
            DropForeignKey("dbo.TB_ATENDIMENTO", "FuncionarioId", "dbo.TB_FUNCIONARIO");
            DropForeignKey("dbo.TB_ATENDIMENTO", "EstabelecimentoId", "dbo.TB_ESTABELECIMENTO");
            DropForeignKey("dbo.TB_TIPO_SERVICO", "EstabelecimentoId", "dbo.TB_ESTABELECIMENTO");
            DropForeignKey("dbo.TB_ENDERECO_JURIDICO", "PessoaJuridicaId", "dbo.TB_PESSOA_JURIDICA");
            DropForeignKey("dbo.TB_ENDERECO_JURIDICO", "EstadoId", "dbo.TB_ESTADO");
            DropForeignKey("dbo.TB_ENDERECO_JURIDICO", "CidadeId", "dbo.TB_CIDADE");
            DropForeignKey("dbo.TB_ENDERECO", "CidadeId", "dbo.TB_CIDADE");
            DropForeignKey("dbo.TB_CIDADE", "EstadoId", "dbo.TB_ESTADO");
            DropForeignKey("dbo.TB_ENDERECO", "PessoaId", "dbo.TB_PESSOA");
            DropForeignKey("dbo.TB_HISTORICO_AGENDA", "TipoDeServicoId", "dbo.TB_TIPO_SERVICO");
            DropForeignKey("dbo.TB_HISTORICO_AGENDA", "FuncionarioId", "dbo.TB_FUNCIONARIO");
            DropForeignKey("dbo.TB_USUARIO", "IdPessoa", "dbo.TB_PESSOA");
            DropForeignKey("dbo.TB_ENDERECO", "EstadoId", "dbo.TB_ESTADO");
            DropForeignKey("dbo.TB_ATENDIMENTO", "ClienteId", "dbo.TB_CLIENTE");
            DropIndex("dbo.TB_FUNCIONARIO", new[] { "EstabelecimentoId" });
            DropIndex("dbo.TB_FUNCIONARIO", new[] { "IdPessoa" });
            DropIndex("dbo.TB_ESTABELECIMENTO", new[] { "IdPessoaJuridica" });
            DropIndex("dbo.TB_CLIENTE", new[] { "IdPessoa" });
            DropIndex("dbo.TB_TIPO_SERVICO", new[] { "EstabelecimentoId" });
            DropIndex("dbo.TB_HISTORICO_AGENDA", new[] { "TipoDeServicoId" });
            DropIndex("dbo.TB_HISTORICO_AGENDA", new[] { "FuncionarioId" });
            DropIndex("dbo.TB_HISTORICO_AGENDA", new[] { "ClienteId" });
            DropIndex("dbo.TB_USUARIO", new[] { "IdPessoa" });
            DropIndex("dbo.TB_ENDERECO", new[] { "EstadoId" });
            DropIndex("dbo.TB_ENDERECO", new[] { "CidadeId" });
            DropIndex("dbo.TB_ENDERECO", new[] { "PessoaId" });
            DropIndex("dbo.TB_CIDADE", new[] { "EstadoId" });
            DropIndex("dbo.TB_ENDERECO_JURIDICO", new[] { "EstadoId" });
            DropIndex("dbo.TB_ENDERECO_JURIDICO", new[] { "CidadeId" });
            DropIndex("dbo.TB_ENDERECO_JURIDICO", new[] { "PessoaJuridicaId" });
            DropIndex("dbo.TB_ATENDIMENTO", new[] { "EstabelecimentoId" });
            DropIndex("dbo.TB_ATENDIMENTO", new[] { "TipoDeServicoId" });
            DropIndex("dbo.TB_ATENDIMENTO", new[] { "FuncionarioId" });
            DropIndex("dbo.TB_ATENDIMENTO", new[] { "ClienteId" });
            DropIndex("dbo.TB_AGENDA", new[] { "EstabelecimentoId" });
            DropIndex("dbo.TB_AGENDA", new[] { "TipoDeServicoId" });
            DropIndex("dbo.TB_AGENDA", new[] { "FuncionarioId" });
            DropIndex("dbo.TB_AGENDA", new[] { "ClienteId" });
            DropTable("dbo.TB_FUNCIONARIO");
            DropTable("dbo.TB_ESTABELECIMENTO");
            DropTable("dbo.TB_CLIENTE");
            DropTable("dbo.TB_TIPO_SERVICO");
            DropTable("dbo.TB_HISTORICO_AGENDA");
            DropTable("dbo.TB_USUARIO");
            DropTable("dbo.TB_ENDERECO");
            DropTable("dbo.TB_ESTADO");
            DropTable("dbo.TB_CIDADE");
            DropTable("dbo.TB_ENDERECO_JURIDICO");
            DropTable("dbo.TB_PESSOA_JURIDICA");
            DropTable("dbo.TB_ATENDIMENTO");
            DropTable("dbo.TB_PESSOA");
            DropTable("dbo.TB_AGENDA");
        }
    }
}
