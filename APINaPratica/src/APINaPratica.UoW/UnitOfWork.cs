using APINaPratica.Domain.Interfaces.Repositories;

namespace APINaPratica.UoW
{
    /// <summary>
    /// responsável pela coordenação da transação quando temos 
    /// mais de um MongoDB ou seja o mesmo está trabalhando em cluster.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMongoContext _context;

        public UnitOfWork(IMongoContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            var changeAmount = await _context.SaveChanges();

            return changeAmount > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
