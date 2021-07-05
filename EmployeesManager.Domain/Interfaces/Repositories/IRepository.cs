using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeesManager.Domain.Interfaces.Repositories
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task<T> Add(T entity);

        T Update(T entity);

        void Delete(Guid id);

        Task<IList<T>> GetAll();

        Task<T> GetById(Guid id);
    }
}
