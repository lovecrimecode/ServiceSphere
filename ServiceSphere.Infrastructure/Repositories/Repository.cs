using Microsoft.EntityFrameworkCore;
using ServiceSphere.Domain.Interfaces;
using ServiceSphere.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceSphere.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ServiceSphereDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ServiceSphereDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>(); // Acceso a la tabla específica para T
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
