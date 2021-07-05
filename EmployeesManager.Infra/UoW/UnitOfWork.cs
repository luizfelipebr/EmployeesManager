using EmployeesManager.Domain.Interfaces.Repositories;

namespace EmployeesManager.Infra.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeesAdminContext _context;

        public UnitOfWork(EmployeesAdminContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
