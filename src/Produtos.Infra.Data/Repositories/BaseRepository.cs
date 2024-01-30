using Microsoft.EntityFrameworkCore;
using Produtos.Domain.Interfaces.Repositories;
using Produtos.Infra.Data.Contexts;

namespace Produtos.Infra.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly SqlServerContext _context;

        public BaseRepository(SqlServerContext context)
        {
            _context = context;
        }

        public async virtual Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async virtual Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async virtual Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async virtual Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async virtual Task<TEntity> GetAsync(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
