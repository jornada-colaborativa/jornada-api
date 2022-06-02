using APINaPratica.Application.Services.Interfaces;
using APINaPratica.Dto.Animal;
using Microsoft.AspNetCore.Mvc;

namespace APINaPratica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalAppService _animalAppService;

        public AnimalController(IAnimalAppService animalAppService)
        {
            _animalAppService = animalAppService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AnimalDto),200)]
        [ProducesResponseType(typeof(BadRequestObjectResult),400)]
        public async Task<IActionResult> Get(Guid Id)
        {

            try
            {
                AnimalDto animal = new AnimalDto();
                animal.Id = Id;
                var animalRetorno = await _animalAppService.GetAnimalAsync(animal);
                return Ok(animalRetorno);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }        
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(AnimalDto), 200)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        public async Task<IActionResult> Delete(Guid Id)
        {

            try
            {
                AnimalDto animal = new AnimalDto();
                animal.Id = Id;
                var animalRetorno = await _animalAppService.DeleteAnimalAsync(animal);
                return Ok(animalRetorno);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(AnimalDto), 200)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        public async Task<IActionResult> GetAll()
        {

            try
            {
                var animalRetorno = await _animalAppService.GetAllAnimalAsync();
                return Ok(animalRetorno);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(AnimalDto), 200)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        public async Task<IActionResult> Post(AnimalDto animalDto)
        {
            try
            {
                var animalRetorno = await _animalAppService.AddAnimalAsync(animalDto);
                return Ok(animalRetorno);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(AnimalDto), 200)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        public async Task<IActionResult> Put(AnimalDto animalDto)
        {
            try
            {
                var animalRetorno = await _animalAppService.UpdateAnimalAsync(animalDto);
                return Ok(animalRetorno);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
