namespace Produtos.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface base para os repositórios
    /// </summary>
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);

        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(Guid id);
    }
}
