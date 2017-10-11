using SBP.Domain.SharedKernel.Events;
using SBP.Domain.SharedKernel.Interfaces;
using SBP.Infra.Data.UoW;

namespace SBP.Application
{
    public class BaseApp
    {
        private readonly IUnitOfWork _unitOfWork;
        protected readonly IHandler<DomainNotification> _notifications;
        //protected UsuarioCadastradoHandler _usuarioCadastradoHandler;

        public BaseApp(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _notifications = DomainEvent.Container.GetInstance<IHandler<DomainNotification>>();
            //_usuarioCadastradoHandler = DomainEvent.Container.GetInstance<UsuarioCadastradoHandler>();
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications())
                return false;

            _unitOfWork.Commit();
            return true;
        }
    }
}
