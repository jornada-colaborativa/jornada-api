using APINaPratica.Domain.Entities.Animal;
using APINaPratica.Domain.Interfaces.Repositories;

namespace APINaPratica.Infra.Mongo.Repository
{
/// <summary>
/// Responsável pelo repositório do objeto animal no repositório de dados
/// ela faz a herança do repositório base onde todos os métodos de 
/// interção com o repositório são criados.
/// </summary>
    public class AnimalRepository : BaseRepository<Animal>, IAnimalRepository
    {
        public AnimalRepository(IMongoContext context) : base(context)
        {
        }
    }
}
