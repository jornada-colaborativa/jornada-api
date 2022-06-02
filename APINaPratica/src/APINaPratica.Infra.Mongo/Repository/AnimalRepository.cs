using APINaPratica.Domain.Entities.Animal;
using APINaPratica.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APINaPratica.Infra.Mongo.Repository
{
    public class AnimalRepository : BaseRepository<Animal>, IAnimalRepository
    {
        public AnimalRepository(IMongoContext context) : base(context)
        {
        }
    }
}
