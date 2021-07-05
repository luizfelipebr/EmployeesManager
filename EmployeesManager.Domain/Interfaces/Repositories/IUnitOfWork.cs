using System;

namespace EmployeesManager.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
