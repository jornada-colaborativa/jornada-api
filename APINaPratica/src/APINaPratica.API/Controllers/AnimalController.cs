using APINaPratica.Application.Services.Interfaces;
using APINaPratica.Dto.Animal;
using Microsoft.AspNetCore.Mvc;

/*Porta de entrada da API*/
namespace APINaPratica.API.Controllers
{
    /// <summary>
    /// Rota utilizada pela aplicação para chegar nos WebMétodos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]   
    /*
     * Informamos aqui o tipo de chamada e respostas esperado que 
     * neste caso é em formato .json
     */
    [Produces("application/json")]
    [Consumes("application/json")]
    
    public class AnimalController : ControllerBase
    {
        /// <summary>
        /// como utilizamos injeção de dependência temos que especificar
        /// aqui qual é a interface que vamos utilizar para 
        /// acessar o APPService.
        /// </summary>
        private readonly IAnimalAppService _animalAppService;
        public AnimalController(IAnimalAppService animalAppService)
        {
            _animalAppService = animalAppService;
        }

        /// <summary>
        /// O HttpGet informado está esperando um Id como parâmetro
        /// da chamada para poder retornar um Objeto do tipo IActionResult
        /// que irá retornar dentro da ação um objeto do tipo mencionado.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Retorna um código de status que 
        /// ser for 200 retorna também o objeto em formato .json
        /// e se for 400 recebe um objeto de erro padrão.</returns>
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

        /// <summary>
        /// O HttpDelete informado está esperando um Id como parâmetro
        /// da chamada para poder retornar um Objeto do tipo IActionResult
        /// que irá retornar dentro da ação um objeto do tipo mencionado.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Retorna um código de status que 
        /// ser for 200 retorna também o objeto em formato .json
        /// e se for 400 recebe um objeto de erro padrão.</returns>
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

        /// <summary>
        /// O HttpGetAll informado retorna todos os Objetos deste tipo no banco
        /// com o IActionResult e também uma Lista de objetos.
        /// que irá retornar dentro da ação um objeto do tipo mencionado.
        /// </summary>
        /// <returns>Retorna um código de status que 
        /// ser for 200 retorna também o objeto em formato .json
        /// e se for 400 recebe um objeto de erro padrão.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<AnimalDto>), 200)]
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

        /// <summary>
        /// O HttpPost informado é utilizado para adicionar um objeto na 
        /// coleção então ele espera receber um .json com o objeto que deve
        /// ser adcionado na coleção e também retorna um 
        /// IActionResult com o objeto que foi gravado na coleção.
        /// </summary>
        /// <returns>Retorna um código de status que 
        /// ser for 200 retorna também o objeto em formato .json
        /// e se for 400 recebe um objeto de erro padrão.</returns>
        /// <param name="animalDto"></param>
        /// <returns></returns>        
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

        /// <summary>
        /// O HttpPut informado é utilizado para atualizar um objeto na 
        /// coleção então ele espera receber um .json com o objeto que deve
        /// ser alterado na coleção e também retorna um 
        /// IActionResult com o objeto que foi gravado na coleção.
        /// </summary>
        /// <returns>Retorna um código de status que 
        /// ser for 200 retorna também o objeto em formato .json
        /// e se for 400 recebe um objeto de erro padrão.</returns>
        /// <param name="animalDto"></param>
        /// <returns></returns>        
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
