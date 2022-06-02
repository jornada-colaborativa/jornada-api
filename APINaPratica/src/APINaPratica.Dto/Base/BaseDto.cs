using Swashbuckle.AspNetCore.Annotations;

namespace APINaPratica.Dto.Base
{
    public class BaseDto
    {
        [SwaggerSchema("Id do dado para controle.")]
        public Guid Id { get; set; }
        [SwaggerSchema("Data de atualização do dado.")]
        public DateTime Atualizacao { get; set; }
        [SwaggerSchema("Data de cadastro do dado.")]
        public DateTime Cadastro { get; set; }
    }
}
