/* Parte do código que informamos para o compilador que 
 * bibliotecas serão utilizadas para poder rodar e compilar
 * esta classe
 */
using APINaPratica.Domain.Entities.Animal;

namespace APINaPratica.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Repositório que herda do repositório principal
    /// passando a informação que pertende a classe
    /// Animal
    /// </summary>
    public interface IAnimalRepository : IRepository<Animal>
    {
    }
}
