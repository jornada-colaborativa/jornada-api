using MongoDB.Driver;

namespace APINaPratica.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface de acesso ao contexto do mongoDB
    /// </summary>
    public interface IMongoContext : IDisposable
    {
        void AddCommand(Func<Task> func);
        Task<int> SaveChanges();
        IMongoCollection<T> GetCollection<T>(string name);
    }
}