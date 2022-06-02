using APINaPratica.Domain.Entities.Animal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APINaPratica.Domain.Interfaces.Repositories
{
    public interface IAnimalRepository : IRepository<Animal>
    {
    }
}
