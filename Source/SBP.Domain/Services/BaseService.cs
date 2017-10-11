using DomainValidation.Validation;
using SBP.Domain.SharedKernel.Events;
using System.Linq;

namespace SBP.Domain.Services
{
    public class BaseService
    {
        public bool PossuiConformidade(ValidationResult validationResult)
        {
            var notifications = validationResult.Erros.Select(validationError => new DomainNotification(validationError.ToString(), validationError.Message)).ToList();

            if (!notifications.Any()) return false;

            notifications.ToList().ForEach(DomainEvent.Raise);

            return true;
        }
    }
}
