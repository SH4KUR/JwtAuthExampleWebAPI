using JwtAuthExample.Core.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using JwtAuthExample.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthExample.Core.Repositories
{
    public class EfRepository<T> : IAsyncRepository<T> where T : class
    {
        private readonly ApplicationContext _context;

        protected EfRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

        public async Task<IReadOnlyList<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        
        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
