namespace APINaPratica.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface base do Repository onde todas as classes de 
    /// repositório irão ter por herança os mesmos métodos para 
    /// chamada do repositório
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        void Update(TEntity obj);
        void Remove(Guid id);
    }
}