using SBP.Infra.Data.Context;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;

namespace SBP.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private SalaoAgendadorContext _context;

        public UnitOfWork(SalaoAgendadorContext dbContext)
        {
            _context = dbContext;
        }

        public void Commit()
        {
            //_context.SaveChanges();

            //Apagar depois do desenvolvimento estiver acertado
            try
            {
#if DEBUG

                _context.ChangeTracker.DetectChanges(); // Force EF to match associations.
                var objectContext = ((IObjectContextAdapter)_context).ObjectContext;
                var objectStateManager = objectContext.ObjectStateManager;
                var fieldInfo = objectStateManager.GetType().GetField("_entriesWithConceptualNulls", BindingFlags.Instance | BindingFlags.NonPublic);
                var conceptualNulls = fieldInfo.GetValue(objectStateManager);

#endif

                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }

        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
