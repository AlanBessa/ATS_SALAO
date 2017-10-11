using Microsoft.Practices.Unity;
using SBP.Application;
using SBP.Application.Interfaces;
using SBP.Domain.Interfaces.Repositories;
using SBP.Domain.Interfaces.Services;
using SBP.Domain.Services;
using SBP.Domain.SharedKernel.Events;
using SBP.Domain.SharedKernel.Handlers;
using SBP.Domain.SharedKernel.Interfaces;
using SBP.Infra.Data.Context;
using SBP.Infra.Data.Repositories;
using SBP.Infra.Data.UoW;

namespace SBP.Infra.CrossCutting.IoC.Containeres
{
    public class BootStrapper
    {
        public static void Register(UnityContainer container)
        {
            // APP
            container.RegisterType<IUsuarioApp, UsuarioApp>(new HierarchicalLifetimeManager());
            container.RegisterType<IFuncionarioApp, FuncionarioApp>(new HierarchicalLifetimeManager());
            container.RegisterType<IClienteApp, ClienteApp>(new HierarchicalLifetimeManager());
            container.RegisterType<ITipoDeServicoApp, TipoDeServicoApp>(new HierarchicalLifetimeManager());
            container.RegisterType<ICidadeApp, CidadeApp>(new HierarchicalLifetimeManager());
            container.RegisterType<IEstadoApp, EstadoApp>(new HierarchicalLifetimeManager());
            container.RegisterType<IEstabelecimentoApp, EstabelecimentoApp>(new HierarchicalLifetimeManager());
            container.RegisterType<IAgendaApp, AgendaApp>(new HierarchicalLifetimeManager());

            // Domain
            container.RegisterType<IUsuarioService, UsuarioService>(new HierarchicalLifetimeManager());
            container.RegisterType<IFuncionarioService, FuncionarioService>(new HierarchicalLifetimeManager());
            container.RegisterType<IClienteService, ClienteService>(new HierarchicalLifetimeManager());
            container.RegisterType<IEnderecoService, EnderecoService>(new HierarchicalLifetimeManager());
            container.RegisterType<ITipoDeServicoService, TipoDeServicoService>(new HierarchicalLifetimeManager());
            container.RegisterType<ICidadeService, CidadeService>(new HierarchicalLifetimeManager());
            container.RegisterType<IEstadoService, EstadoService>(new HierarchicalLifetimeManager());
            container.RegisterType<IEnderecoJuridicoService, EnderecoJuridicoService>(new HierarchicalLifetimeManager());
            container.RegisterType<IEstabelecimentoService, EstabelecimentoService>(new HierarchicalLifetimeManager());
            container.RegisterType<IAgendaService, AgendaService>(new HierarchicalLifetimeManager());

            // Infra Dados Repos
            container.RegisterType<IUsuarioRepository, UsuarioRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IFuncionarioRepository, FuncionarioRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IClienteRepository, ClienteRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IEnderecoRepository, EnderecoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITipoDeServicoRepository, TipoDeServicoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICidadeRepository, CidadeRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IEstadoRepository, EstadoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IEnderecoJuridicoRepository, EnderecoJuridicoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IEstabelecimentoRepository, EstabelecimentoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IAgendaRepository, AgendaRepository>(new HierarchicalLifetimeManager());

            // Infra Dados
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<SalaoAgendadorContext>(new HierarchicalLifetimeManager());

            // Handlers
            container.RegisterType<IHandler<DomainNotification>, DomainNotificationHandler>(new HierarchicalLifetimeManager());
            //container.RegisterType<IHandler<UsuarioCadastradoEvent>, UsuarioCadastradoHandler>(new HierarchicalLifetimeManager());

            // Identity
            //container.RegisterType<ApplicationDbContext>();
            //container.RegisterType<ApplicationUserManager>();            
            //container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new InjectionConstructor(typeof(ApplicationDbContext)));
        }
    }
}
