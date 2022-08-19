using Microsoft.EntityFrameworkCore;
using MyFinancial.Data.Entities;
using MyFinancial.Data.Repositories.Interfaces;

namespace MyFinancial.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        private readonly MyFinancialDbContext _context;

        public RepositoryBase(MyFinancialDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll(string[]? includes = null)
        {
            var set = _context.Set<T>().AsQueryable();

            if (includes != null)
                foreach (var include in includes)
                {
                    set = set.Include(include);
                }

            return set;
        }

        public T? GetById(int id, string[]? includes = null)
        {
            var set = _context.Set<T>().AsQueryable();

            if (includes != null)
                foreach (var include in includes)
                {
                    set = set.Include(include);
                }

            return set.FirstOrDefault(x => x.Id == id);
        }

        public T AddOrUpdate(T entity)
        {
            if (entity.Id == 0)
            {
                entity.CreatedAt = DateTime.Now;

                _context.Set<T>().Add(entity);
            }
            else
            {
                entity.UpdatedAt = DateTime.Now;

                _context.Set<T>().Update(entity);
            }

            return entity;
        }

        public bool Delete(int id)
        {
            var entity = GetById(id);

            if(entity != null)
            {
                _context.Set<T>().Remove(entity);

                return true;
            }

            return false;
        }

        public void SaveChanges() => _context.SaveChanges();
    }
}
