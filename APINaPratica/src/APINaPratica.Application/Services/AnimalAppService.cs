using APINaPratica.Application.Services.Interfaces;
using APINaPratica.Domain.Entities.Animal;
using APINaPratica.Domain.Interfaces.Repositories;
using APINaPratica.Dto.Animal;

namespace APINaPratica.Application.Services
{
    public class AnimalAppService : IAnimalAppService
    {
        /// <summary>
        /// Injeção de dependência utilizada para acessar o repositório
        /// </summary>
        private readonly IAnimalRepository _animalRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AnimalAppService(IAnimalRepository animalRepository, IUnitOfWork unitOfWork)
        {
            _animalRepository = animalRepository;
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// responsável por adicionar no repositório
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<AnimalDto> AddAnimalAsync(AnimalDto record)
        {

            try
            {
                Animal animal = new Animal()
                {
                    Apelido = record.Apelido,
                    Atualizacao = DateTime.UtcNow,
                    Cadastro = DateTime.UtcNow,
                    CorPredominante = record.CorPredominante,
                    Nascimento = record.Nascimento,
                    Nome = record.Nome,
                    Porte = record.Porte,
                    Raca = record.Raca,
                    Id = Guid.NewGuid()
                };

                _animalRepository.Add(animal);

                var entity = await _animalRepository.GetById(animal.Id);

                await _unitOfWork.Commit();

                if (entity != null)
                {
                    AnimalDto animalDto = new AnimalDto()
                    {
                        Apelido = entity.Apelido,
                        Atualizacao = entity.Atualizacao,
                        Cadastro = entity.Cadastro,
                        CorPredominante = entity.CorPredominante,
                        Nascimento = entity.Nascimento,
                        Nome = entity.Nome,
                        Porte = entity.Porte,
                        Raca = entity.Raca,
                        Id = entity.Id
                    };

                    return animalDto;

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return null;

        }
        /// <summary>
        /// resposável por deletar do repositório
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAnimalAsync(AnimalDto record)
        {
            try
            {
                var entity = await _animalRepository.GetById(record.Id);

                if (entity != null)
                    _animalRepository.Remove(record.Id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// responsável por recuperar do repositório
        /// </summary>
        /// <returns></returns>
        public async Task<IList<AnimalDto>> GetAllAnimalAsync()
        {
            IList<AnimalDto> animais = new List<AnimalDto>();

            var entities = await _animalRepository.GetAll();

            foreach (var entity in entities)
            {
                AnimalDto animalDto = new AnimalDto()
                {
                    Apelido = entity.Apelido,
                    Atualizacao = entity.Atualizacao,
                    Cadastro = entity.Cadastro,
                    CorPredominante = entity.CorPredominante,
                    Nascimento = entity.Nascimento,
                    Nome = entity.Nome,
                    Porte = entity.Porte,
                    Raca = entity.Raca,
                    Id = entity.Id
                };

                animais.Add(animalDto);


            }
            return animais;
        }
        /// <summary>
        /// Responsável por recuperar do repositório
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public async Task<AnimalDto> GetAnimalAsync(AnimalDto record)
        {

            var entity = await _animalRepository.GetById(record.Id);

                AnimalDto animalDto = new AnimalDto()
                {
                    Apelido = entity.Apelido,
                    Atualizacao = entity.Atualizacao,
                    Cadastro = entity.Cadastro,
                    CorPredominante = entity.CorPredominante,
                    Nascimento = entity.Nascimento,
                    Nome = entity.Nome,
                    Porte = entity.Porte,
                    Raca = entity.Raca,
                    Id = entity.Id
                };

            return animalDto;
        }

        /// <summary>
        /// responsável por atualizar no repositório
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<AnimalDto> UpdateAnimalAsync(AnimalDto record)
        {
            try
            {
                var entity = await _animalRepository.GetById(record.Id);

                entity.Apelido = record.Apelido;
                entity.Atualizacao = DateTime.UtcNow;
                entity.Cadastro = entity.Cadastro;
                entity.CorPredominante = record.CorPredominante;
                entity.Nascimento = record.Nascimento;
                entity.Nome = record.Nome;
                entity.Porte = record.Porte;
                entity.Raca = record.Raca;
                entity.Id = record.Id;

                _animalRepository.Update(entity);

                await _unitOfWork.Commit();

                var animalReturn = await _animalRepository.GetById(record.Id);


                if (entity != null)
                {
                    AnimalDto animalDto = new AnimalDto()
                    {
                        Apelido = animalReturn.Apelido,
                        Atualizacao = animalReturn.Atualizacao,
                        Cadastro = animalReturn.Cadastro,
                        CorPredominante = animalReturn.CorPredominante,
                        Nascimento = animalReturn.Nascimento,
                        Nome = animalReturn.Nome,
                        Porte = animalReturn.Porte,
                        Raca = animalReturn.Raca,
                        Id = animalReturn.Id
                    };

                    return animalDto;

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return null;
        }
    }
}
