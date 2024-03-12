namespace Produtos.Domain.Interfaces.Repositories;

public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
{
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);

    Task<List<TEntity>> GetAllAsync();
    Task<TEntity> GetAsync(Guid id);
}
