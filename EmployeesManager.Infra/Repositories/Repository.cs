using EmployeesManager.Domain.Entities;
using EmployeesManager.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeesManager.Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase<T>
    {
        protected EmployeesAdminContext Db;
        protected DbSet<T> DbSet;

        public Repository(EmployeesAdminContext context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }

        ~Repository()
        {
            Dispose(false);
        }

        public async Task<T> Add(T entity)
        {
            var result = await DbSet.AddAsync(entity);
            return result.Entity;
        }

        public void Delete(Guid id)
        {
            var validEntity = GetById(id).GetAwaiter().GetResult();
            DbSet.Remove(validEntity);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<IList<T>> GetAll()
        {
            var result = await DbSet.ToListAsync();
            return result;
        }

        public async Task<T> GetById(Guid id)
        {
            var entity = await GetById(id);
            return entity;
        }

        public T Update(T entity)
        {
            return DbSet.Update(entity).Entity;
        }

        private void Dispose(bool status)
        {
            if (!status) return;
        }
    }
}
