namespace APINaPratica.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface do unit of work utilizada para 
    /// orquestrar o commit no repositório de dados.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}