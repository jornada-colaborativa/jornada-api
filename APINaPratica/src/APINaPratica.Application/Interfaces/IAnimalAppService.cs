using APINaPratica.Dto.Animal;

namespace APINaPratica.Application.Services.Interfaces
{
    /// <summary>
    /// interfaces do AppService.
    /// </summary>
    public interface IAnimalAppService
    {
        Task<AnimalDto> GetAnimalAsync(AnimalDto record);
        Task<IList<AnimalDto>> GetAllAnimalAsync();
        Task<AnimalDto> AddAnimalAsync(AnimalDto record);
        Task<AnimalDto> UpdateAnimalAsync(AnimalDto record);
        Task<Boolean> DeleteAnimalAsync(AnimalDto record);
    }
}
